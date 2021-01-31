using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuUIController mainMenuMenuUIController;

    public static Action startButtonClicked;

    public void StartChosenMode()
    {
        OnStartButtonClicked();
    }

    private void OnStartButtonClicked()
    {
        startButtonClicked?.Invoke();
        LoadChosenModeScene();
    }

    private void LoadChosenModeScene()
    {
        int indexOfSceneToLoad = (int) ModeManager.Instance.chosenMode;
        SceneManager.LoadSceneAsync(indexOfSceneToLoad);
    }
}
