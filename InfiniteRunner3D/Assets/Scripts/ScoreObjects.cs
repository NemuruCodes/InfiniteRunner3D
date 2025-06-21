using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class ScoreObjects : MonoBehaviour
{
    public PointManager pointManager = PointManager.Instance;
    
    private const int _weakpoints = 4, _medpoints = 6, _highpoints = 8;

    private string obstacle;

    private void OnEnable()
    {
        GameEvents.Instance.OnScorePoints += AddPoints;
    }

    private void OnDisable()
    {
        GameEvents.Instance.OnScorePoints -= AddPoints;
    }

    public void AddPoints(int amount)
    {
        pointManager.value += amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Rocket"))
        {
            string obstacleName = other.name.ToLower();
            int basePoints = 0;

            if (obstacleName.Contains("crate01") || obstacleName.Contains("debri01"))
                basePoints = _weakpoints;
            else if (obstacleName.Contains("rocket"))
                basePoints = _highpoints;
            else if (obstacleName.Contains("scaffholding"))
                basePoints = _medpoints;

            if (basePoints > 0)
            {
                int totalPoints = PickUpManagerV2.IsPointBuffActive ? basePoints * 2 : basePoints;
                GameEvents.Instance.ObstaclePassed(totalPoints);
            }
        }
    }


    /*
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
    */
}
