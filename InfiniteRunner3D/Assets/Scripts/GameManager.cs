using System.Collections;
using UnityEngine;

public enum LevelState
{
    Level1,
    Transition,
    Level2
}
public class GameManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject tilePrefab2;

    public GameObject trans1;
    public GameObject trans2;

    public float tileSpacing = 12f;
    public float FirstSpawn = 108f;
    private Vector3 spawnPos;
    public SpawnObstaclesOnTiles objectSpawner;

    //PointManager pointManager;

    public bool Transitioned = false;

    private Coroutine activeTileRoutine;

    private LevelState currentLevel = LevelState.Level1;

    void Start()
    {
        spawnPos = new Vector3(0, 0, FirstSpawn);
        activeTileRoutine = StartCoroutine(SpawnTiles());
    }

    private void Update()
    {
        if(PointManager.Instance.nextLevel == true)
        {
            if (activeTileRoutine != null)
            {
                //Debug.Log("stop Lv1 tile");
                StopCoroutine(activeTileRoutine);
            }


            switch (currentLevel)
            {
                case LevelState.Level1:
                    activeTileRoutine = StartCoroutine(SpawnTiles2());
                    currentLevel = LevelState.Level2;
                    Transitioned = false;
                    break;

                case LevelState.Level2:

                    activeTileRoutine = StartCoroutine(SpawnTiles1());
                    currentLevel = LevelState.Level1;
                    Transitioned = false;
                    break;
            }

            //activeTileRoutine = StartCoroutine(SpawnTiles2());

            PointManager.Instance.nextLevel = false;
        }
    }
    
    private IEnumerator SpawnTiles()
    {
        while (true)
        {
           
                yield return new WaitForSeconds(1.5f);
                GameObject newTile = Instantiate(tilePrefab, spawnPos, Quaternion.identity);
                objectSpawner.SpawnObjectsOnTile(newTile.transform);
                spawnPos.z += tileSpacing;
            
    
        }
    }
    
    private IEnumerator SpawnTiles2()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);

                if (!Transitioned)
                {
                   
                    GameObject nextTile = Instantiate(trans1, spawnPos, Quaternion.identity);
                    objectSpawner.SpawnObjectsOnTile(nextTile.transform);
                    spawnPos.z += tileSpacing;
                    Transitioned = true;
                }
                else
                {
                    //yield return new WaitForSeconds(1.5f);    
                    GameObject nextTile = Instantiate(tilePrefab2, spawnPos, Quaternion.identity);
                    objectSpawner.SpawnObjectsOnTile(nextTile.transform);
                    spawnPos.z += tileSpacing;
                }

            
    
        }
    }
    private IEnumerator SpawnTiles1()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.5f);

            if (!Transitioned)
            {

                GameObject nextTile = Instantiate(trans2, spawnPos, Quaternion.identity);
                objectSpawner.SpawnObjectsOnTile(nextTile.transform);
                spawnPos.z += tileSpacing;
                Transitioned = true;
            }
            else if (Transitioned)
            {
                //yield return new WaitForSeconds(1.5f);    
                GameObject nextTile = Instantiate(tilePrefab, spawnPos, Quaternion.identity);
                objectSpawner.SpawnObjectsOnTile(nextTile.transform);
                spawnPos.z += tileSpacing;
            }
        }
      
    }


    /*
    public Transform tileObject;
    private Vector3 spawnNextTile;

    public Transform cratesObj;
    private Vector3 spawnNextCrates;

    public Transform debriObj;
    private Vector3 spawnNextDebri;

    public Transform scaffholdingObj;
    private Vector3 spawnNextScaff;

    public Transform Enemy;
    private Vector3 spawnNextEnemy;

    public Transform PickUp;
    private Vector3 spawnNextPickup;


    //private int rand_x;

    private readonly float[] lanes = { -3f, 0f, 3f };

    private int randChoice;

    void Start()
    {
        spawnNextTile.z = 96;
        StartCoroutine(spawnTile());
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerController>().JumpEffect = 1;
        //PickUpManager.canJump = true;
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
        spawnNextCrates.y = 3.1f;

        Instantiate(tileObject, spawnNextTile, tileObject.rotation);
        Instantiate(cratesObj, spawnNextCrates, cratesObj.rotation);


        spawnNextTile.z += 12;

        //rand_x = Random.Range(-3, 3);
        randomLane = lanes[Random.Range(0, lanes.Length)];
        spawnNextDebri.z = spawnNextTile.z;
        spawnNextDebri.y = 3f;

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
        randChoice = Random.Range(0, 2);
        if (randChoice == 0) 
        {

            spawnNextScaff.z = spawnNextTile.z;
            spawnNextScaff.y = 3.1f;
            spawnNextScaff.x = randomLane;
            //Instantiate(tileObject, spawnNextTile, tileObject.rotation);
            Instantiate(scaffholdingObj, spawnNextScaff, scaffholdingObj.rotation);


        }
        else 
        {

            spawnNextEnemy.z = spawnNextTile.z;
            spawnNextEnemy.y = 3.1f;
            spawnNextEnemy.x = randomLane;
            Instantiate(Enemy, spawnNextEnemy, Enemy.rotation);
        }


        randomLane = lanes[Random.Range(0, lanes.Length)];
         if(randomLane == 0) 
        {
            randomLane = -3;
        
        }
        else if (randomLane == 3) 
        {
            randomLane = 0;
        
        }
        else if (randomLane == -3) 
        {
            randomLane = 3;
        
        
        }
        spawnNextPickup.z = spawnNextTile.z;
        spawnNextPickup.y = 3.1f;
        spawnNextPickup.x = randomLane;
        Instantiate(PickUp, spawnNextPickup,PickUp.rotation);

        spawnNextTile.z += 12;
        StartCoroutine(spawnTile());


    }
    */
}
