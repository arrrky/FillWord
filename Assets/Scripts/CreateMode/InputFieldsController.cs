using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldsController : MonoBehaviour
{
    [SerializeField] private List<InputField> inputFields;

    public static int lettersCount = 0;
    private const int LettersLimit = 100;

    public static Action LetterCountUpdated;

    void Start()
    {
      
    }

    public void UpdateLetterCount()
    {
        lettersCount = 0;
        foreach (InputField inputField in inputFields)
        {
            lettersCount += inputField.text.Length;
        }
        OnLetterCountUpdated();

        if (lettersCount == LettersLimit)
        {
            foreach (InputField inputField in inputFields)
            {
                inputField.interactable = false;
            }
        }
    }

    private void OnLetterCountUpdated()
    {
        LetterCountUpdated?.Invoke();
    }

    
}
