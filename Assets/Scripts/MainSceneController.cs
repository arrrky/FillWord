using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private GameObject fieldElementPrefab;
    [SerializeField] private GameObject fieldElementsParent;
    [FormerlySerializedAs("spriteRenderer")] [SerializeField] private Sprite sprite;

    [SerializeField] [Range(2,10)] private int fieldWidth = 10;
    [SerializeField] [Range(2,10)] private int fieldHeight = 10;

    private Vector2Int _startPosition;
    private Vector2 _spriteShift;

    private ILettersField _lettersField;
    
    private void Start()
    {
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
        
        _startPosition = new Vector2Int(- fieldWidth / 2, - fieldHeight / 2);
        _spriteShift = GetSpriteShift();

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
