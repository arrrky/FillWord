using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Mode
{
    Create = 0,
    Play = 1,
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
