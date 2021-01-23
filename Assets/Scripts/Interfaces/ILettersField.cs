

using UnityEngine.UI;

public interface ILettersField : IField
{
   Text[,] Letters { get; set; }
   void LettersFieldInit();
   void UpdateWithRandomLetters();
}
