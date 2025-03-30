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

    private int rand_x;


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
        rand_x = Random.Range(-5, 6);
        spawnNextCrates = spawnNextTile;
        spawnNextCrates.x = rand_x;
        spawnNextCrates.y = 3.65f;

        Instantiate(tileObject, spawnNextTile, tileObject.rotation);
        Instantiate(cratesObj, spawnNextCrates, cratesObj.rotation);


        spawnNextTile.z += 12;
        rand_x = Random.Range(-5, 6);
        spawnNextDebri.z = spawnNextTile.z;
        spawnNextDebri.y = 3.5f;
        spawnNextDebri.x = rand_x;


        Instantiate(tileObject, spawnNextTile, tileObject.rotation);
        Instantiate(debriObj, spawnNextDebri, tileObject.rotation);
        spawnNextTile.z += 12;
        StartCoroutine(spawnTile());
    }
}
