using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LettersField : Field, ILettersField
{
    private readonly char[] _englishLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); 
    
    public Text[,] Letters { get; set; }

    public override void Init(int width, int height, Vector3 startPosition, Vector2 spriteShift, GameObject prefab,
        GameObject prefabsParent)
    {
        base.Init(width, height, startPosition, spriteShift, prefab, prefabsParent);

        Letters = new Text[Width,Height];
        
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Letters[x, y] = ObjectsField[x, y].GetComponentInChildren<Text>();
            }
        }
    }

    // Для теста, как и массив английский букв
    public void UpdateWithRandomLetters()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Letters[x, y].text = _englishLetters[Random.Range(0, _englishLetters.Length - 1)].ToString();
            }
        }
    }

    // Простое заполнение слева направо, сверху вниз - работает как кал
    public void FillLetterField(List<char> letters)
    {
        int lettersCount = 0;
        
        for (int y = Height - 1; y >= 0; y--)
        {
            for (int x = 0; x < Width; x++)
            {
                Letters[x, y].text = letters[lettersCount].ToString();
                lettersCount++;
            }
        }
    }
    
    
}
