using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public PointManager pointManager = PointManager.Instance;


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

        pointManager.value = 0;

        Debug.Log("Restart");

        PlayerController.isAlive = true;
    }

}
