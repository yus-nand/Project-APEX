using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private WaveManager waveManager;
    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }
    public void Show()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        if(SaveManager.Instance != null)
            SaveManager.Instance.RecordRunEnd(waveManager.CurrentWave);
    }        
    
    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Debug.Log("Player Quit.");
        Application.Quit();
    }
}
