using UnityEngine;
using System.Collections;

public class TileSpawnerV2 : MonoBehaviour
{
    [Header("Tile Settings")]
    public Transform tilePrefab;
    public float tileSpacing = 12f;
    private Vector3 spawnNextTile = new Vector3(0, 0, 96);

    [Header("Content Prefabs")]
    public Transform cratesPrefab;
    public Transform debrisPrefab;
    public Transform scaffoldingPrefab;
    public Transform enemyPrefab;
    public Transform pickupPrefab;

    [Header("Spawn Y Positions")]
    public float objectY = 3.1f;
    public float debrisY = 3f;

    [Header("Spawn Chance (0-1)")]
    [Range(0f, 1f)] public float spawnCrateChance = 1f;
    [Range(0f, 1f)] public float spawnDebrisChance = 1f;
    [Range(0f, 1f)] public float spawnEnemyChance = 0.5f;
    [Range(0f, 1f)] public float spawnPickupChance = 1f;

    [Header("Spawn Timing")]
    public float spawnDelay = 2f;

    private readonly float[] lanes = { -3f, 0f, 3f };

    void Start()
    {
        StartCoroutine(SpawnTileLoop());
    }

    IEnumerator SpawnTileLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        // === TILE ===
        Instantiate(tilePrefab, spawnNextTile, tilePrefab.rotation);

        // === CRATE ===
        if (Random.value <= spawnCrateChance)
        {
            float crateLane = lanes[Random.Range(0, lanes.Length)];
            Vector3 cratePos = spawnNextTile + new Vector3(crateLane, objectY, 0);
            Instantiate(cratesPrefab, cratePos, cratesPrefab.rotation);
        }

        spawnNextTile.z += tileSpacing;

        // === TILE again for next segment ===
        Instantiate(tilePrefab, spawnNextTile, tilePrefab.rotation);

        // === DEBRIS ===
        float debrisLane = lanes[Random.Range(0, lanes.Length)];
        if (Random.value <= spawnDebrisChance)
        {
            Vector3 debrisPos = new Vector3(debrisLane, debrisY, spawnNextTile.z);
            Instantiate(debrisPrefab, debrisPos, debrisPrefab.rotation);
        }

        // === ENEMY or SCAFFOLDING ===
        float altLane = GetAlternateLane(debrisLane);
        if (Random.value <= spawnEnemyChance)
        {
            Vector3 enemyPos = new Vector3(altLane, objectY, spawnNextTile.z);
            Instantiate(enemyPrefab, enemyPos, enemyPrefab.rotation);
        }
        else
        {
            Vector3 scaffPos = new Vector3(altLane, objectY, spawnNextTile.z);
            Instantiate(scaffoldingPrefab, scaffPos, scaffoldingPrefab.rotation);
        }

        // === PICKUP ===
        float pickupLane = GetAlternateLane(altLane);
        if (Random.value <= spawnPickupChance)
        {
            Vector3 pickupPos = new Vector3(pickupLane, objectY, spawnNextTile.z);
            Instantiate(pickupPrefab, pickupPos, pickupPrefab.rotation);
        }

        // Move forward for the next call
        spawnNextTile.z += tileSpacing;
    }

    float GetAlternateLane(float currentLane)
    {
        if (currentLane == -3f) return 0f;
        if (currentLane == 0f) return 3f;
        return -3f;
    }
    /*
    [Header("References")]
    public Transform player;             // Assign your player here
    public Transform tilePrefab;         // The main ground tile prefab
    public TileContent[] spawnables;     // ScriptableObject assets

    [Header("Settings")]
    public float tileLength = 12f;
    public float spawnAheadDistance = 30f;
    public float spawnInterval = 2f;

    private float nextSpawnZ;

    private readonly float[] lanes = { -3f, 0f, 3f };

    void Start()
    {
        nextSpawnZ = player.position.z + spawnAheadDistance;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnTile();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnTile()
    {
        // Spawn the tile base
        Vector3 tileSpawnPos = new Vector3(0, 0, nextSpawnZ);
        Instantiate(tilePrefab, tileSpawnPos, Quaternion.identity);

        // Prevent overlapping in lanes
        bool[] laneUsed = new bool[lanes.Length];

        foreach (var content in spawnables)
        {
            if (content.prefab == null || Random.value > content.spawnChance)
                continue;

            int laneIndex = Random.Range(0, lanes.Length);

            // Try to find an unused lane
            int attempts = 0;
            while (laneUsed[laneIndex] && attempts < lanes.Length)
            {
                laneIndex = (laneIndex + 1) % lanes.Length;
                attempts++;
            }

            if (laneUsed[laneIndex]) continue; // No lanes available

            laneUsed[laneIndex] = true;

            float laneX = lanes[laneIndex];
            Vector3 spawnPos = tileSpawnPos + new Vector3(laneX, content.offset.y, 0) + content.offset;

            Instantiate(content.prefab, spawnPos, Quaternion.identity);
        }

        nextSpawnZ += tileLength;
    }
    /*
    public Transform tilePrefab;
    public float tileLength = 12f;
    
    public float spawnInterval = 3f;

    public TileContent[] spawnables;

    private Vector3 nextSpawnPos = new Vector3(0, 0, 96);
    private readonly float[] lanes = { -3f, 0f, 3f };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnTile();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

   
    void SpawnTile()
    {
        Debug.Log("Spawning tile and contents at " + nextSpawnPos);
        Instantiate(tilePrefab, nextSpawnPos, Quaternion.identity);

        foreach (var content in spawnables)
        {
            if (Random.value <= content.spawnChance)
            {
                float laneX = lanes[Random.Range(0, lanes.Length)];
                Vector3 spawnPos = nextSpawnPos + new Vector3(laneX, content.offset.y, 0) + content.offset;
                Instantiate(content.prefab, spawnPos, Quaternion.identity);
            }
        }

        nextSpawnPos.z += tileLength;
    }
    */
}
