using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Yojijukugo : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Image _img;

    [SerializeField] private int index;
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;

    private bool _isRotating;

    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
        _img = GetComponent<Image>();

        backSprite = GameManager.Instance.questionData.blankYojijukugoData.sprites[index % 4];
        frontSprite = GameManager.Instance.currentYojijukugoData.sprites[index];
    }

    public void OnClick()
    {
        if (!_isRotating)
        {
            GameManager.Instance.AddCount();
            Rotate();
        }
    }

    void Rotate()
    {
        _isRotating = true;
        _rectTransform.DORotate(new Vector3(0, 90, 0), 0.2f)
            .OnComplete(() =>
            {
                _img.sprite = frontSprite;

                _rectTransform.DORotate(new Vector3(0f, 0f, 0f), 0.2f)
                    .OnComplete(() =>
                    {
                        _rectTransform.DORotate(new Vector3(0, 90, 0), 0.2f).SetDelay(5)
                            .OnComplete(() =>
                            {
                                _img.sprite = backSprite;
                                _rectTransform.DORotate(new Vector3(0f, 0f, 0f), 0.2f).OnComplete(() =>
                                {
                                    _isRotating = false;
                                });
                            });
                    });
            });
    }
}