using UnityEngine;

public class GameManager_ : MonoBehaviour
{
    public static GameManager_ Instance { get; private set; }

    public float gameDuration = 60f;
    public GameObject Player;
    public GameObject StartPoint;
    public RotatingObject Obstacle;
    private bool isGameOver = false;
    private float timer = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (!isGameOver)
        {
            timer += Time.deltaTime;
            UIManager.Instance.UpdateTimerText(gameDuration - timer);

            var time = gameDuration - timer;
            if ((int)time == 0)
            {
                EndGame(true);
            }
        }
    }

    public void EndGame(bool win)
    {
        
        isGameOver = true;
        UIManager.Instance.ShowGameOverPanel(0, win);
    }

    public void RestartGame()
    {
        isGameOver = false;
        timer = 0f;
        ScoreManager.Instance.ResetScore();
        UIManager.Instance.HideGameOver();
        Player.SetActive(true);
        Player.transform.position = StartPoint.transform.position;
        Obstacle.ResetRotation();
    }
}
