using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateModeUIController : MonoBehaviour
{
    [SerializeField] private Button btnCreate;

    [SerializeField] private Text lblLettersCount;
    [SerializeField] private Text lblCreate;


    private void OnEnable()
    {
        LettersCountController.LettersCountUpdated += UpdateLettersCountOnUI;
        LettersCountController.LettersCountReachedMax += MakeCreateButtonInteractable;
    }

    private void Start()
    {
        CreateModeUIInit();
    }

    private void CreateModeUIInit()
    {
        lblLettersCount.text = "Letters count: ";
        lblCreate.text = "Create";
    }

    private void UpdateLettersCountOnUI()
    {
        lblLettersCount.text = $"Letters count: {LettersCountController.LettersCount}";
    }

    private void MakeCreateButtonInteractable()
    {
        btnCreate.interactable = true;
    }

    private void OnDisable()
    {
        LettersCountController.LettersCountUpdated -= UpdateLettersCountOnUI;
        LettersCountController.LettersCountReachedMax -= MakeCreateButtonInteractable;
    }
}