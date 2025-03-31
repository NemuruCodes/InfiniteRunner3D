using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform tileObject;
    private Vector3 spawnNextTile;

    public Transform cratesObj;
    private Vector3 spawnNextCrates;

    public Transform debriObj;
    private Vector3 spawnNextDebri;

    public Transform scaffholdingObj;
    private Vector3 spawnNextScaff;

    //private int rand_x;

    private float[] lanes = { -3f, 0f, 3f };

    void Start()
    {
        spawnNextTile.z = 96;
        StartCoroutine(spawnTile());
    }

    void Update()
    {
        
    }

    IEnumerator spawnTile() 
    { 
        yield return new WaitForSeconds(3);
        //rand_x = Random.Range(-3, 3);
        float randomLane = lanes[Random.Range(0, lanes.Length)];

        spawnNextCrates = spawnNextTile;
        //spawnNextCrates.x = rand_x;
        spawnNextCrates.x = randomLane;
        spawnNextCrates.y = 3.2f;

        Instantiate(tileObject, spawnNextTile, tileObject.rotation);
        Instantiate(cratesObj, spawnNextCrates, cratesObj.rotation);


        spawnNextTile.z += 12;

        //rand_x = Random.Range(-3, 3);
        randomLane = lanes[Random.Range(0, lanes.Length)];
        spawnNextDebri.z = spawnNextTile.z;
        spawnNextDebri.y = 0.5f;
        //spawnNextDebri.x = rand_x;
        spawnNextDebri.x = randomLane;
        Instantiate(tileObject, spawnNextTile, tileObject.rotation);
        Instantiate(debriObj, spawnNextDebri, debriObj.rotation);

        if(randomLane == 0) 
        {
            randomLane = 3;
        
        }
        else if (randomLane == 3) 
        {
            randomLane = -3;
        
        }
        else if (randomLane == -3) 
        {
            randomLane = 0;
        
        
        }

        spawnNextScaff.z = spawnNextTile.z;
        spawnNextScaff.y = 3f;
        spawnNextScaff.x = randomLane;
        //Instantiate(tileObject, spawnNextTile, tileObject.rotation);
        Instantiate(scaffholdingObj, spawnNextScaff, scaffholdingObj.rotation);


        spawnNextTile.z += 12;
        StartCoroutine(spawnTile());
    }
}
