using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldsController : MonoBehaviour
{
    [SerializeField] private List<InputField> inputFields;

    public static int LettersCount = 0;
    private const int LettersLimit = 100;

    public static Action LetterCountUpdated;
    public static Action LetterCountReachedMax;

    public void UpdateLetterCount()
    {
        LettersCount = 0;
        
        foreach (InputField inputField in inputFields)
        {
            LettersCount += inputField.text.Length;
        }
        OnLetterCountUpdated();

        // TODO - оставить поля интерактивными, но не давать набирать еще символы (но разрешить удалять) - через отдельный ограничивающий скрипт?
        if (LettersCount == LettersLimit)
        {
            foreach (InputField inputField in inputFields)
            {
                inputField.interactable = false;
            }
            
            OnLetterCountReachedMax();
        }
        else
        {
            
        }
    }

    private void OnLetterCountUpdated()
    {
        LetterCountUpdated?.Invoke();
    }
    
    private void OnLetterCountReachedMax()
    {
        LetterCountReachedMax?.Invoke();
    }

    public List<string> GetAllWords()
    {
        List<string> result = new List<string>();
        
        foreach (InputField inputField in inputFields)
        {
           result.Add(inputField.text);
        }

        return result;
    }
}
