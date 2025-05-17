using UnityEngine;

public class ScoreObjects : MonoBehaviour
{
    public PointManager pointManager = PointManager.Instance;
    
    private const int _weakpoints = 4, _medpoints = 6, _highpoints = 8;

    private string obstacle;


    private void OnTriggerEnter(Collider other)
    {
        
        if(PickUpManager.PointCheck == true)
        {
            if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Rocket")
            {
                //Debug.Log("Trigger");
                obstacle = other.name.ToLower();

                if (obstacle == "crate01(clone)" || obstacle == "debri01(clone)")
                {
                    pointManager.value += _weakpoints *2;
                    Debug.Log("weak");
                }
                if (obstacle == "rocket(clone)")
                {
                    pointManager.value += _highpoints *2;
                    Debug.Log("Med");

                }
                if (obstacle == "scaffHolding(clone)")
                {
                    pointManager.value += _medpoints * 2;
                    Debug.Log("Big");

                }
            }
        }
        else
        {
            if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Rocket")
            {
                //Debug.Log("Trigger");
                obstacle = other.name.ToLower();

                if (obstacle == "crate01(clone)" || obstacle == "debri01(clone)")
                {
                    pointManager.value += _weakpoints;
                    Debug.Log("weak");
                }
                if (obstacle == "rocket(clone)")
                {
                    pointManager.value += _highpoints;
                    Debug.Log("Med");

                }
                if (obstacle == "scaffHolding(clone)")
                {
                    pointManager.value += _medpoints;
                    Debug.Log("Big");

                }
            }
        }
    }
           
}
