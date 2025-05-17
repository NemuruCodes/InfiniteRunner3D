using UnityEngine;

[CreateAssetMenu(fileName = "TileContent", menuName = "Scriptable Objects/TileContent")]
public class TileContent : ScriptableObject
{
    public GameObject prefab;
    public float spawnChance = 1f;
    public Vector3 offset = Vector3.zero;
}
