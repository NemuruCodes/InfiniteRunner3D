using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/JumpEffects")]
public class JumpEffects : PowerEffects
{
    // Start is called before the first frame update

    public float changeJump;
    public override void ApplyEffect(GameObject target)
    {
        //PlayerController.JumpEffect = 2;
        target.GetComponent<PlayerController>().JumpEffect = 2;
    }

    public override void RemoveEffect(GameObject target)
    {
        target.GetComponent<PlayerController>().JumpEffect = 1;
        PickUpManager.JumpCheck = false;
        Debug.Log("Jump");
    }
}
