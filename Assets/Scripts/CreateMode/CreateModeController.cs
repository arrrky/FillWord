using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CreateModeController : MonoBehaviour
{
    [SerializeField] private InputFieldsController inputFieldsController;
    
    [SerializeField] private GameObject fieldElementPrefab;
    [SerializeField] private GameObject fieldElementsParent;
    [SerializeField] private Sprite sprite;

    [SerializeField] [Range(2,10)] private int fieldWidth = 10;
    [SerializeField] [Range(2,10)] private int fieldHeight = 10;

    private Vector3 _startPosition;
    private Vector2 _spriteShift;

    private ILettersField _lettersField;

    private void Start()
    {
        _spriteShift = GetSpriteShift();
        MainInit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _lettersField.UpdateWithRandomLetters();
        }
    }

    private void MainInit()
    {
        _lettersField = gameObject.AddComponent<LettersField>();
        
        Vector3 screenBounds = MiscTools.GetScreenBounds();
        _startPosition = new Vector3(screenBounds.x / 2 - fieldWidth / 2 - _spriteShift.x, -screenBounds.y + 1, 0);

        _lettersField.Init(fieldWidth, fieldHeight, _startPosition, _spriteShift, fieldElementPrefab, fieldElementsParent);
    }
    
    private Vector2 GetSpriteShift()
    {
        var bounds = sprite.bounds;
        return new Vector2(bounds.extents.x, bounds.extents.y);
    }

    public List<char> letters;
    
    //TODO - выделить в класс
    public void StringToCharConverter(List<string> words)
    {
        words = inputFieldsController.GetAllWords();

        foreach (string word in words)
        {
            for (int i = 0; i < word.Length; i++)
            {
                letters.Add(word[0]);
            }
            
            //letters.Add(' '); // чтобы видеть границы 
        }
    }

    // переименовать - т.к. одинаковые имена тут и в классе lettersfield
    public void FillLetterField()
    {
        StringToCharConverter(inputFieldsController.GetAllWords());
        _lettersField.FillLetterField(letters);
    }
    
}
