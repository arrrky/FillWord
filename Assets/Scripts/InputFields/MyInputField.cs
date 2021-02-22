using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyInputField : InputField
{
   public override void OnSelect(BaseEventData eventData)
   {
      base.OnSelect(eventData);
      SetNewCharacterLimit(LettersCountController.LettersLimit - LettersCountController.LettersCount);
      Debug.Log(this.characterLimit);
   }
   
   private void SetNewCharacterLimit(int newCharacterLimit)
   {
      this.characterLimit = newCharacterLimit;
   }
}
