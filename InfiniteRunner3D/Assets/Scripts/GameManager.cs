using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform tileObject;
    private Vector3 spawnNextTile;
    public Transform cratesObj;
    private Vector3 spawnNextCrates;
    private int rand_x;


    void Start()
    {
        spawnNextTile.z = 60;
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
        spawnNextCrates.y = 1.2f;

        Instantiate(tileObject, spawnNextTile, tileObject.rotation);
        Instantiate(cratesObj, spawnNextCrates, cratesObj.rotation);
        spawnNextTile.z += 15;


        Instantiate(tileObject, spawnNextTile, tileObject.rotation);
        spawnNextTile.z += 15;
        StartCoroutine(spawnTile());
    }
}
