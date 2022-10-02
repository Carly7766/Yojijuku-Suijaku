using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestionData : ScriptableObject
{
    [SerializeField] public YojijukugoData blankYojijukugoData;
    [SerializeField] public YojijukugoData[] yojijukugoDatas;
}

[System.Serializable]
public struct YojijukugoData
{
    [SerializeField] public Sprite[] sprites;
    [SerializeField] public string answer;
    [SerializeField, Multiline] public string meaning;
}