using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public TMP_Text TimerText;
    // Punch animation variables
    public float punchDuration = 0.5f;
    public float punchAmount = 0.5f;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        Punch(scoreText.transform);
    }


    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
        scoreText.text = "Score: " + 0;
    }

    public void ShowGameOverPanel(int finalScore, bool win)
    {
        if (win)
        {
            finalScoreText.text = "You won! your score is: " + finalScore.ToString();
            AudioController.Instance.PlaySFX(2);
        }
        else
        {
            AudioController.Instance.PlaySFX(1);
            finalScoreText.text = "Keep trying! your score is: " + finalScore.ToString();
        }

        
        gameOverPanel.SetActive(true);
        Punch(finalScoreText.transform);
        
    }

    public void UpdateTimerText(float value)
    {

        var intValue= (int)value;
        TimerText.text = "Time: " + intValue.ToString();


    }
public void ShowMainMenu()
    {


    }

    public void Punch(Transform target)
    {
        // Create a punch animation sequence using DoTween
        Sequence punchSequence = DOTween.Sequence();
        punchSequence.Append(target.DOPunchScale(new Vector3(punchAmount, punchAmount, punchAmount), punchDuration));
    }


}
