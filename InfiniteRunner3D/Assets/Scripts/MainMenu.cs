using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SettingsLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }

    public void Close()
    {
        SceneManager.UnloadSceneAsync("SettingsMenu");
    }
}
