using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;
[System.Serializable]
public class DATA
{
    [field: SerializeField]
    public List<WorldInfo> WorldData { get; private set; }

}

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    [field: SerializeField] public DATA Data { get; private set; }

    public static int key = 129;

    public static string EncryptDecrypt(string textToEncrypt)
    {
        StringBuilder inSb = new StringBuilder(textToEncrypt);
        StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
        char c;
        for (int i = 0; i < textToEncrypt.Length; i++)
        {
            c = inSb[i];
            c = (char)(c ^ key);
            outSb.Append(c);
        }
        return outSb.ToString();
    }
    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            LoadSavedGames();
        }
    }

    public void SetRecord(float timer, int levelIndex, int worldIndex, FantomeSave fantome)
    {
        if (Data.WorldData[worldIndex].MapData[levelIndex].HighScore == 0)
        {
            Data.WorldData[worldIndex].MapData[levelIndex].HighScore = timer ;
            Data.WorldData[worldIndex].MapData[levelIndex].fantome = fantome;
            if (PlayFabHighScore.Instance)
                PlayFabHighScore.Instance.UpdateHighScoreCloud(Data.WorldData[worldIndex].MapData[levelIndex].SceneData.MapName, -timer * 1000);
        }

        if (timer < Data.WorldData[worldIndex].MapData[levelIndex].HighScore)
        {
            Data.WorldData[worldIndex].MapData[levelIndex].fantome = fantome;
            Data.WorldData[worldIndex].MapData[levelIndex].HighScore = timer;
            if (PlayFabHighScore.Instance)
                PlayFabHighScore.Instance.UpdateHighScoreCloud(Data.WorldData[worldIndex].MapData[levelIndex].SceneData.MapName, -timer * 1000);


            if (levelIndex + 1 != Data.WorldData[worldIndex].MapData.Count)
                Data.WorldData[worldIndex].MapData[levelIndex + 1].HaveUnlockLevel = true;
        }

        SaveData();
    }

    public void SaveData()
    {   
        string data = JsonUtility.ToJson(Data);
        string filepath = Application.persistentDataPath + "/Save.json";
        File.WriteAllText(filepath, EncryptDecrypt(data));
    }

    //Charge tous les record dans toutes les maps et les charges dans les Datas;
    public void LoadSavedGames()
    {
        string worldsFolder = Application.persistentDataPath + "/Save.json";
        if (File.Exists(worldsFolder))
        {
            string fileContents = File.ReadAllText(worldsFolder);
            DATA data = JsonUtility.FromJson<DATA>(EncryptDecrypt(fileContents));
            for (int i = 0; i < Data.WorldData.Count; i++)
            {
                if (data.WorldData[i] != null)
                {
                    Data.WorldData[i].HaveUnlockWorld = data.WorldData[i].HaveUnlockWorld;

                    for (int j = 0; j < Data.WorldData[i].MapData.Count; j++)
                    {
                        if (data.WorldData[i].MapData[j] != null)
                        {
                            Data.WorldData[i].MapData[j].HighScore = data.WorldData[i].MapData[j].HighScore;
                            Data.WorldData[i].MapData[j].HaveUnlockLevel = data.WorldData[i].MapData[j].HaveUnlockLevel;
                            Data.WorldData[i].MapData[j].fantome = data.WorldData[i].MapData[j].fantome;
                        }
                    }
                }
            }
        }
    }

    public MapData GetActualMapData(int index, int worldIndex) { return Data.WorldData[worldIndex].MapData[index]; }

}

[System.Serializable]

public class MapData
{
    [field: SerializeField] public SceneObject SceneData { get; private set; }
    public float HighScore;
    public bool HaveUnlockLevel = true;
    public FantomeSave fantome;
}

[System.Serializable]
public class WorldInfo
{
    [field: SerializeField] public string WorldName { get; private set; }
    public bool HaveUnlockWorld = true;
    [field: SerializeField] public List<MapData> MapData { get; private set; }
}