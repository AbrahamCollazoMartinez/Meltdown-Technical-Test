using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonPopupAnimation : MonoBehaviour
{
    public Button button;
    public float scaleAmount = 1.2f;
    public float animationDuration = 0.2f;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = button.transform.localScale;
        button.onClick.AddListener(PopupAnimation);
    }

    private void PopupAnimation()
    {
        button.transform.DOScale(originalScale * scaleAmount, animationDuration)
            .SetEase(Ease.OutBack)
            .OnComplete(() => button.transform.DOScale(originalScale, animationDuration));
    }
}
