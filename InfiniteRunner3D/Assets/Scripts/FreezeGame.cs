using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    [SerializeField] private GameObject EndMenu;
    [SerializeField] private GameObject TextUI;
    [SerializeField] private GameObject Score;

    [SerializeField] private GameObject PauseMenu;

    public Vector3 targetPosition;
    public float speed = 5f;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")|| collision.gameObject.CompareTag("Rocket"))
        {
            

            EndMenu.SetActive(true);

            TextUI.transform.position = Vector3.Lerp(TextUI.transform.position, targetPosition, speed * 1);

            Score.SetActive(false);

            Time.timeScale = 0;
        }

     

   
    }

    public void PauseGame() 
    {
        PauseMenu.SetActive(true);

        Time.timeScale = 0; 


    } 

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);

        Time.timeScale = 1;
    }
}
