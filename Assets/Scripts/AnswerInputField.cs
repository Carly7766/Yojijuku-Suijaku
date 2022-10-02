using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerInputField : MonoBehaviour
{
    private InputField _inputField;

    private void OnEnable()
    {
        _inputField = GetComponent<InputField>();
        _inputField.text = "";
    }

    public bool VerifyText(string text)
    {
        return _inputField.text == text;
    }
}