using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UserInputControllerCreateMode : MonoBehaviour
{
    [SerializeField] private InputFieldsController inputFieldsController;

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputFieldsController.TabBetweenInputFields();
        }
    }
}
