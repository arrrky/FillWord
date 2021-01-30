using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LettersField : Field, ILettersField
{
    private readonly char[] _englishLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); 
    
    public Text[,] Letters { get; set; }

    public void LettersFieldInit()
    {
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
}
