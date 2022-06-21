using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // make sure to add this script to the scene's root object
    // this script will handle the scene transitions
    //  make singleton
    public static SceneLoader Instance;

    public GameObject loadingScreen;

    public CanvasGroup canvasGroup;

    [Scene]
    public string[] levels;

    [Scene]
    public string mainScene;

    private int currentLevelIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy (gameObject);
        }
        DontDestroyOnLoad (gameObject);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(StartLoad(sceneName));
    }

    IEnumerator StartLoad(string sceneName)
    {
        loadingScreen.SetActive(true);
        yield return StartCoroutine(FadeLoadingScreen(1, 1));
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
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
            canvasGroup.alpha =
                Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }

    public void LoadNextLevel()
    {
        if (currentLevelIndex < levels.Length - 1)
        {
            LoadScene(levels[currentLevelIndex + 1]);
            currentLevelIndex++;
        }
        else
        {
            LoadScene (mainScene);
        }
    }
}
