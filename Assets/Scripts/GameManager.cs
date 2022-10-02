using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] public QuestionData questionData;

    [SerializeField] public YojijukugoData currentYojijukugoData;
    public List<YojijukugoData> yojijukugoDatas;
    public List<YojijukugoData> usedYojijukugoDatas;

    [SerializeField] private GameObject titleCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject clearCanvas;

    [SerializeField] private AnswerInputField _answerInputField;
    [SerializeField] private AnswerText _answerText;

    public int count;

    public delegate void CountUpDelegate(int count);

    public CountUpDelegate OnCountUp;

    protected override void Awake()
    {
        base.Awake();
        yojijukugoDatas = questionData.yojijukugoDatas.ToList();
    }

    public void StartGame()
    {
        currentYojijukugoData = LotteryYojijukugo();
        titleCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void AddCount()
    {
        count++;
        OnCountUp(count);
    }

    public void VerifyAnswer()
    {
        if (_answerInputField.VerifyText(currentYojijukugoData.answer))
        {
            gameCanvas.SetActive(false);
            clearCanvas.SetActive(true);
        }
        else
        {
            _answerText.ShowIncorrectText();
        }
    }

    public void RetryGame()
    {
        count = 0;
        currentYojijukugoData = LotteryYojijukugo();
        clearCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    private YojijukugoData LotteryYojijukugo()
    {
        if (yojijukugoDatas.Count == 0)
        {
            yojijukugoDatas.AddRange(usedYojijukugoDatas);
            usedYojijukugoDatas.Clear();
        }

        var selectYojijukugo = yojijukugoDatas[Random.Range(0, yojijukugoDatas.Count)];
        usedYojijukugoDatas.Add(selectYojijukugo);
        yojijukugoDatas.Remove(selectYojijukugo);

        return selectYojijukugo;
    }
}

public enum GameState
{
    Title,
    Game,
    Answer
}