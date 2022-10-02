using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.VerifyAnswer();
    }
}
