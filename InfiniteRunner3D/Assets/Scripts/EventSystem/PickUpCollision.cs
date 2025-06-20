using UnityEngine;

public enum PickupType
{
    Bullet,
    Jump,
    Shield,
    Point
}
public class PickUpCollision : MonoBehaviour
{
    public PickupType pickupType;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        switch (pickupType)
        {
            case PickupType.Bullet: GameEvents.Instance.BulletPicked(); break;
            case PickupType.Jump: GameEvents.Instance.JumpPicked(); break;
            case PickupType.Shield: GameEvents.Instance.ShieldPicked(); break;
            case PickupType.Point: GameEvents.Instance.PointPicked(); break;
        }
        Destroy(gameObject);
    }
}
