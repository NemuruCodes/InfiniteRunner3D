using UnityEngine;

public class PointManager : MonoBehaviour
{
    
    public static PointManager Instance {  get; private set; }

    public int value = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
