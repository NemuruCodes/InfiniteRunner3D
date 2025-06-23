using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    public static FreezeGame Instance { get; private set; }

    [SerializeField] private GameObject EndMenu;
    [SerializeField] private GameObject TextUI;
    [SerializeField] private GameObject Score;

    [SerializeField] private GameObject BossScore;
    [SerializeField] private GameObject BossUI;

    [SerializeField] private GameObject PauseMenu;

    public Vector3 targetPosition;
    public float speed = 5f;

    public Vector3 targetPosition2;

    public PlayerMetrics playerMetrics;
    public int valueFinal { get; set; }
    public int BossFinal { get; set; }
    PointManager pointManager;


    public void PlayerDeath()
    {

        EndMenu.SetActive(true);

        //TextUI.transform.position = Vector3.Lerp(TextUI.transform.position, targetPosition, speed * 1);

        //BossScore.transform.position = Vector3.Lerp(BossScore.transform.position, targetPosition2, speed * 1);

        //Score.SetActive(false);
        //BossUI.SetActive(false);

        // Time.timeScale = 0;
        //SoundManager.StopLoopingSound(SoundType.FACTORY);

       // pointManager.PlayerDeathCount();
        playerMetrics.LogIn();
        playerMetrics.Add(PointManager.Instance.value, PointManager.Instance.value, PointManager.Instance.bossesDefeated);

        //playerMetrics.Add(pointManager.value, pointManager.value, pointManager.bossesDefeated);
        playerMetrics.LogIn();

        Time.timeScale = 0;
        SoundManager.StopLoopingSound(SoundType.FACTORY);

    }
    /*
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
    */
    public void PauseGame() 
    {
        PauseMenu.SetActive(true);

        Time.timeScale = 0;
        SoundManager.StopLoopingSound(SoundType.FACTORY);

    } 

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);

        Time.timeScale = 1;

        SoundManager.PlaySoundLoop(SoundType.FACTORY);
    }
}
