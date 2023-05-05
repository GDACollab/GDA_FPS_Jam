using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Loading screen from https://www.youtube.com/watch?v=wvXDCPLO7T0
public class MainMenu : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public SettingsManager Settings;

    public void PlayGame()
    {
        if (Settings.settingsOpen == false)
        {
            StartCoroutine(LoadSceneAsync(1));
        }
    }

    public void OpenSettings()
    {
        Settings.toggleUI();
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progessValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingBarFill.fillAmount = progessValue;

            yield return null;
        }
    }
}
