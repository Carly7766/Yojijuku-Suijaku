using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    private Text _text;

    private void OnEnable()
    {
        _text = GetComponent<Text>();

        string resultText = null;
        switch (GameManager.Instance.count)
        {
            case <= 4:
                resultText = $"{GameManager.Instance.count}回で正解！？天才ですか！？";
                break;
            case <= 8:
                resultText = $"{GameManager.Instance.count}回で正解！すばらしい！";
                break;
            case >= 16:
                resultText = $"{GameManager.Instance.count}回で正解！知らない四字熟語でしたか？";
                break;
            default:
                resultText = $"{GameManager.Instance.count}回で正解！";
                break;
        }

        _text.text = resultText;
    }
}