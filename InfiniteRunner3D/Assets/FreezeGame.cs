using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    [SerializeField] private GameObject EndMenu;
    [SerializeField] private GameObject TextUI;
    [SerializeField] private GameObject Score;

    public Vector3 targetPosition;
    public float speed = 5f;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0;

            EndMenu.SetActive(true);

            TextUI.transform.position = Vector3.Lerp(TextUI.transform.position, targetPosition, speed * 1);

            Score.SetActive(false);
        }

     

   
}
}
