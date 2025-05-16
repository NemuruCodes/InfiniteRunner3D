using UnityEngine;

public class ScoreObjects : MonoBehaviour
{
    public PointManager pointManager = PointManager.Instance;
    
    private const int _weakpoints = 4, _medpoints = 8, _highpoints = 12;

    private string obstacle;


    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.tag == "Obstacle")
        {
            //Debug.Log("Trigger");
            obstacle = other.name.ToLower();

            if (obstacle == "crate01(clone)" || obstacle == "debri01(clone)") 
            { 
                pointManager.value += _weakpoints;
            }
            if (obstacle == "rocket(clone)") 
            {
                pointManager.value += _highpoints;
            
            
            }
            if (obstacle == "scaffHolding(clone)") 
            {
                pointManager.value += _medpoints;


            }
        }
    }
}
