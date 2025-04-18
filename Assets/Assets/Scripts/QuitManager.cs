using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitManager : MonoBehaviour
{
    public GameObject quitPanel;

    public void QuitGame()
    {
     
        Time.timeScale = 0f;
        quitPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public GameObject menuPanel;

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }
    public void SoundNotAvailable()
    {
        Debug.Log("Sound is not included in this version of the game.");
        
    }

}
