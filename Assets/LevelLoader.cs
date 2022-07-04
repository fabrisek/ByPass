using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    public GameObject loadingScreen;
    public CanvasGroup canvasGroup;

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

    public void StartLoadScene(int index)
    {
        StartCoroutine(StartLoad(index));
    }
    IEnumerator StartLoad(int index)
    {
        loadingScreen.SetActive(true);
        yield return StartCoroutine(FadeLoadingScreen(1, 1));
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
