using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoText : MonoBehaviour
{
    private Text _text;
    
    private void OnEnable()
    {
        _text = GetComponent<Text>();
        _text.text = "めくった回数:0";
        GameManager.Instance.OnCountUp += UpdateCount;
    }

    public void UpdateCount(int count)
    {
        _text.text = $"めくった回数:{count}";
    }
}
