using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int lives = 100;
    public int score = 0;

    public TMP_Text livesText;
    public TMP_Text scoreText;

    private bool gameOver = false;
    private float scoreInterval = 1f;
    private float scoreTimer = 0f;

    public Transform respawnPoint;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

       
        lives = 3;
        score = 0;
        gameOver = false;
    }

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (!gameOver)
        {
            scoreTimer += Time.deltaTime;
            if (scoreTimer >= scoreInterval)
            {
                IncreaseScore();
                scoreTimer = 0f;
            }
        }
    }

    void IncreaseScore()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        score++;
        UpdateUI();
    }

    public void DecreaseLife()
    {
        lives--;

        if (lives <= 0)
        {
            gameOver = true;
            GameManager.Instance.isGameOver = true;
        }

        UpdateUI();
    }

    public void AddLife()
    {
        lives++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;

        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
