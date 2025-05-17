using UnityEngine;
using System.Collections;

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
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            if (Random.value <= spawnChances[i])
            {
                float laneX = lanes[Random.Range(0, lanes.Length)];
                GetAlternateLane(laneX);
                Vector3 spawnPos = new Vector3(tile.position.x + laneX, spawnY, tile.position.z);
                Instantiate(obstaclePrefabs[i], spawnPos, obstaclePrefabs[i].rotation);
                
            }
        }
    }
    float GetAlternateLane(float currentLane)
    {
        if (currentLane == -3f) return 0f;
        if (currentLane == 0f) return 3f;
        return -3f;
    }
}
