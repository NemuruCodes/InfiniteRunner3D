using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnObstaclesOnTiles : MonoBehaviour
{
    [Header("Obstacles")]
    public Transform[] obstaclePrefabs;

    [Tooltip("Spawn chance for each obstacle (0 to 1).")]
    [Range(0f, 1f)]
    public float[] spawnChances;

    [Header("Obstacle Spawn Settings")]
    public float spawnY = 3.1f;
    private readonly float[] lanes = { -3f, 0f, 3f };

    void Start()
    {
        SpawnOnAllGroundTiles();
    }

    public void SpawnOnAllGroundTiles()
    {
        GameObject[] groundTiles = GameObject.FindGameObjectsWithTag("Ground");

        foreach (GameObject tile in groundTiles)
        {
            SpawnObjectsOnTile(tile.transform);
        }
    }

    public void SpawnObjectsOnTile(Transform tile)
    {
        HashSet<float> usedLanes = new HashSet<float>();

        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            if (Random.value <= spawnChances[i])
            {
                float laneX;
                int maxAttempts = 10;
                int attempts = 0;

                do
                {
                    laneX = lanes[Random.Range(0, lanes.Length)];
                    attempts++;
                }
                while (usedLanes.Contains(laneX) && attempts < maxAttempts);

                if (usedLanes.Contains(laneX)) continue;

                usedLanes.Add(laneX);
                    
                laneX = lanes[Random.Range(0, lanes.Length)];
               
                Vector3 spawnPos = new Vector3(tile.position.x + laneX, spawnY, tile.position.z);
                Instantiate(obstaclePrefabs[i], spawnPos, obstaclePrefabs[i].rotation);
                
            }
        }
    }
   
}
