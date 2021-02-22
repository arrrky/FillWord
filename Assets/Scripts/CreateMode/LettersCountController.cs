using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersCountController : MonoBehaviour
{
    [SerializeField] private InputFieldsController inputFieldsController;
    
    public static int LettersCount;
    public static readonly int LettersLimit = 100;
    
    public static Action LettersCountUpdated;
    public static Action LettersCountReachedMax;
    
    public void UpdateLetterCount()
    {
        LettersCount = inputFieldsController.GetInputFieldsSymbolsCount();
        OnLetterCountUpdated();

        if (LettersCount == LettersLimit)
        {
            OnLetterCountReachedMax();
        }
    }
    
    private void OnLetterCountUpdated()
    {
        LettersCountUpdated?.Invoke();
    }

    private void OnLetterCountReachedMax()
    {
        LettersCountReachedMax?.Invoke();
    }
}
