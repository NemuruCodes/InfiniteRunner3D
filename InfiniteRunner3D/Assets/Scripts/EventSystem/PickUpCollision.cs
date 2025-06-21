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
            case PickupType.Bullet: GameEvents.Instance.BulletPicked();
                SoundManager.PlaySound(SoundType.SHOOT, 0.8f);
                break;
            case PickupType.Jump: GameEvents.Instance.JumpPicked();
                SoundManager.PlaySound(SoundType.PICKUP, 0.8f);
                break;
            case PickupType.Shield: GameEvents.Instance.ShieldPicked();
                SoundManager.PlaySound(SoundType.SHIELD);
                break;
            case PickupType.Point: GameEvents.Instance.PointPicked();
                SoundManager.PlaySound(SoundType.PICKUP, 0.8f);
                break;
        }
        Destroy(gameObject);
    }
}
