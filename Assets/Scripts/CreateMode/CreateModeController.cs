using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateModeController : MonoBehaviour
{
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

        _lettersField.FieldInit(fieldWidth, fieldHeight, _startPosition, _spriteShift, fieldElementPrefab, fieldElementsParent);
        _lettersField.CreateField();
        _lettersField.LettersFieldInit();
    }
    
    private Vector2 GetSpriteShift()
    {
        var bounds = sprite.bounds;
        return new Vector2(bounds.extents.x, bounds.extents.y);
    }
}
