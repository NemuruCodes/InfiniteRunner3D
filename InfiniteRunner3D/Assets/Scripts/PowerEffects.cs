using UnityEngine;

[CreateAssetMenu(fileName = "PowerEffects", menuName = "Scriptable Objects/PowerEffects")]
public abstract class PowerEffects : ScriptableObject
{
    public abstract void ApplyEffect(GameObject target);

    public abstract void RemoveEffect(GameObject target);

}
