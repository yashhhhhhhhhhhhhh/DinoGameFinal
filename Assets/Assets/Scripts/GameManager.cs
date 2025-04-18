using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameSpeed = 5f;
    public float speedIncreaseRate = 0.1f;
    public bool isGameOver;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
 

        isGameOver = false; 
    }

    void Update()
    {
        if (!isGameOver)
        {
            gameSpeed += speedIncreaseRate * Time.deltaTime;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        isGameOver = true;
       
    }
}
