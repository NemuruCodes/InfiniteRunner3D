using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private string Settings = "SettingsMenu";

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private GameObject BossKillUI;

    private bool isPaused = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuControle();
        }
    }

    public void FreezeGame()
    {
        Time.timeScale = 0f;
    }

    public void UnFreezeGame()
    {
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


    public void SettingsLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Additive);
    }

    public void Close()
    {
        SceneManager.UnloadSceneAsync(Settings);
    }

    public void PauseMenuControle()
    {
        if (isPaused == false)
        {
            pausePanel.SetActive(true);
            UIPanel.SetActive(false);
            BossKillUI.SetActive(false);
            isPaused = true;
            FreezeGame();
        }

        else if (isPaused == true)
        {
            pausePanel.SetActive(false);
            UIPanel.SetActive(true);
            BossKillUI.SetActive(true);
            isPaused = false;
            UnFreezeGame();
        }
    }

}

