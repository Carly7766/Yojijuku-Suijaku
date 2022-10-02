using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeaningText : MonoBehaviour
{
    private Text _text;
    private void OnEnable()
    {
        _text = GetComponent<Text>();
        _text.text = GameManager.Instance.currentYojijukugoData.meaning;
    }
}
