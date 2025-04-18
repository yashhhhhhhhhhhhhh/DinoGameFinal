using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public CanvasGroup gameOverCanvasGroup;
    public float fadeSpeed = 1f;
    private bool isFading = false;

    void Start()
    {
        if (gameOverCanvasGroup != null)
        {
            gameOverCanvasGroup.alpha = 0f;
            gameOverCanvasGroup.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver && !isFading)
        {
            ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        if (gameOverCanvasGroup == null) return;

        gameOverCanvasGroup.gameObject.SetActive(true);

        if (!isFading)
        {
            StartCoroutine(FadeInGameOver());
        }
    }

    System.Collections.IEnumerator FadeInGameOver()
    {
        isFading = true;

        while (gameOverCanvasGroup != null && gameOverCanvasGroup.alpha < 1f)
        {
            gameOverCanvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        if (gameOverCanvasGroup != null)
            gameOverCanvasGroup.alpha = 1f;

        isFading = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
