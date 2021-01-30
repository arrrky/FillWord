using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
   [SerializeField] private GameObject mainSceneUIGroup;
   
   [SerializeField] private Text lblAppName;
   [SerializeField] private Text lblChooseMode;
   [SerializeField] private Text lblCreate;
   [SerializeField] private Text lblPlay;
   [SerializeField] private Text lblStart;

   private void OnEnable()
   {
      MainSceneController.startButtonClicked += HideMainSceneUI;
   }

   private void Start()
   {
      // Можно добавить локализацию в будущем
      lblAppName.text = "FillWord";
      lblChooseMode.text = "Choose mode";
      lblCreate.text = "Create";
      lblPlay.text = "Play";
      lblStart.text = "Start";
   }

   private void HideMainSceneUI()
   {
      mainSceneUIGroup.SetActive(false);
   }

   private void OnDisable()
   {
      MainSceneController.startButtonClicked -= HideMainSceneUI;
   }
}
