using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Mode
{
    MainMenu = 0,
    Create = 1,
    Play = 2,
}

public class ModeManager : MonoBehaviour
{
    public static ModeManager Instance;

    public Mode chosenMode;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            chosenMode = Mode.Create;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChooseMode(Toggle toggle)
    {
        string toggleName = toggle.name;

        switch (toggleName)
        {
            case "tglCreate":
                chosenMode = Mode.Create;
                break;
            
            case "tglPlay":
                chosenMode = Mode.Play;
                break;
        }
    }
}
