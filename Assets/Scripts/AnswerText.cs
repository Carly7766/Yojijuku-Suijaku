using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerText : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void ShowIncorrectText()
    {
        StartCoroutine(ShowIncorrectTextCoroutine());
    }

    IEnumerator ShowIncorrectTextCoroutine()
    {
        _text.color = Color.red;
        _text.text = "不正解...";
        _text.enabled = true;
        yield return new WaitForSeconds(1);
        _text.enabled = false;
    }
}