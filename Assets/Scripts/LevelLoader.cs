using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] CanvasGroup canvasGroup;

    [SerializeField] string[] allTips;
    [SerializeField] TextMeshProUGUI _textTips;
    [SerializeField] Image ImageBackGround;
    [SerializeField] TextMeshProUGUI _nameLevel;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void ChangeCanvas(SceneObject obj)
    {
        int rand = Random.Range(0, allTips.Length);
        _textTips.text = allTips[rand];
        ImageBackGround.sprite = obj.BackGroundLoad;
        _nameLevel.text = obj.MapName;
    }

    public void StartLoadScene(SceneObject obj)
    {
        StartCoroutine(StartLoad(obj.IndexScene));
        ChangeCanvas(obj);
    }
    IEnumerator StartLoad(int index)
    {
        loadingScreen.SetActive(true);
        yield return StartCoroutine(FadeLoadingScreen(1, 3));
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        loadingScreen.SetActive(false);
    }
    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
}
