using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldsController : MonoBehaviour
{
    [SerializeField] private List<MyInputField> inputFields;

    private void OnEnable()
    {
        LettersCountController.LettersCountReachedMax += LockAllInputFields;
    }

    private void Start()
    {
        inputFields[0].Select();
    }

    public int GetInputFieldsSymbolsCount()
    {
        int result = 0;

        foreach (MyInputField inputField in inputFields)
        {
            result += inputField.text.Length;
        }

        return result;
    }

    // Костыль, но пока так
    // TODO - придумать лучший способ
    public void LockAllInputFields()
    {
        foreach (MyInputField inputField in inputFields)
        {
            inputField.interactable = false;
        }
    }

    public void UnlockAllInputFields()
    {
        foreach (MyInputField inputField in inputFields)
        {
            inputField.interactable = true;
        }
    }

    public List<string> GetAllWords()
    {
        List<string> result = new List<string>();

        foreach (MyInputField inputField in inputFields)
        {
            result.Add(inputField.text);
        }

        return result;
    }

    public void TabBetweenInputFields()
    {
        MyInputField selectedInputField = FindSelectedInputField();

        int indexOfSelectedInputField = inputFields.IndexOf(selectedInputField);

        if (selectedInputField != null)
        {
            if (indexOfSelectedInputField == inputFields.Count - 1)
            {
                inputFields[0].Select();
            }
            else
            {
                inputFields[indexOfSelectedInputField + 1].Select();
            }
        }
    }

    private MyInputField FindSelectedInputField()
    {
        foreach (MyInputField inputField in inputFields)
        {
            if (inputField.isFocused)
            {
                return inputField;
            }
        }

        return null;
    }
    
    private void OnDisable()
    {
        LettersCountController.LettersCountReachedMax -= LockAllInputFields;
    }
}