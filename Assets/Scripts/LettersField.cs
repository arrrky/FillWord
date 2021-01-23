using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LettersField : Field, ILettersField
{
   
    private char[] englishLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); 
    
    public Text[,] Letters { get; set; }

    public void LettersFieldInit()
    {
        Letters = new Text[Width,Height];
        
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Letters[x, y] = field[x, y].GetComponentInChildren<Text>();
            }
        }
    }

    public void UpdateWithRandomLetters()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Letters[x, y].text = englishLetters[Random.Range(0, englishLetters.Length - 1)].ToString();
            }
        }
    }
}
