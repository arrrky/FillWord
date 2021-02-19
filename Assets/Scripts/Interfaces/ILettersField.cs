using System.Collections.Generic;
using UnityEngine.UI;

public interface ILettersField : IField
{
   Text[,] Letters { get; set; }
   void UpdateWithRandomLetters();
   void FillLetterField(List<char> letters);
}
