using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;
using System.IO;
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
            SaveData();
            LoadSavedGames();
        }
    }

    public void SetRecord(float timer, int levelIndex, int worldIndex)
    {
        /*if (Data.WorldData[worldIndex].MapData[levelIndex].GetHighScore() == 0)
        {
            Data.WorldData[worldIndex].MapData[levelIndex].SetHighScore(timer);
            print(timer);
            /*if (PlayFabHighScore.Instance)
                PlayFabHighScore.Instance.SendLeaderBord(timer, Data_Manager.Instance.GetData()._worldData[worldIndex]._mapData[levelIndex].GetSceneData().MapName);

            if (PhantomeControler.Instance != null)
            {
                Data.WorldData[worldIndex]._mapData[levelIndex].SetPhantomeSave(PhantomeControler.Instance.phantomeSave);
            }
        }

        if (timer < Data.WorldData[worldIndex].MapData[levelIndex].GetHighScore())
        {
            //Data.WorldData[worldIndex].MapData[levelIndex].SetHighScore(timer);
            //if (PlayFabHighScore.Instance)
                //PlayFabHighScore.Instance.SendLeaderBord(timer, Data_Manager.Instance.GetData()._worldData[worldIndex]._mapData[levelIndex].GetSceneData().MapName);

            /*if (PhantomeControler.Instance != null)
            {
                Data.WorldData[worldIndex]._mapData[levelIndex].SetPhantomeSave(PhantomeControler.Instance.phantomeSave);
            }*/
        

        //if (levelIndex + 1 != Data.WorldData[worldIndex].MapData.Count)
            //Data.WorldData[worldIndex].MapData[levelIndex + 1].SetHaveUnlockLevel(true);

        //SaveData();*/
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
                            //Data.WorldData[i].MapData[j].SetHighScore(data.WorldData[i].MapData[j].GetHighScore());
                            //Data.WorldData[i].MapData[j].SetHaveUnlockLevel(data.WorldData[i].MapData[j].GetHaveUnlockLevel());
//                            Data.WorldData[i]._mapData[j].SetPhantomeSave(data.WorldData[i]._mapData[j].GetPhantomSave());

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
    [field: SerializeField] public float HighScore { get; set; }
    [field: SerializeField] public bool HaveUnlockLevel { get; set; }
}

[System.Serializable]
public class WorldInfo
{
    [field: SerializeField] public string WorldName { get; private set; }
    [field: SerializeField] public bool HaveUnlockWorld { get; set; }
    [field: SerializeField] public List<MapData> MapData { get; private set; }
}