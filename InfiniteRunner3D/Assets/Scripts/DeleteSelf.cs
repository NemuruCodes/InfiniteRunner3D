using UnityEngine;

public class DeleteSelf : MonoBehaviour
{
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
    
