using UnityEngine;

[CreateAssetMenu(fileName = "DestructionUtil", menuName = "ScriptableObjects/Utils/Destruction Util")]
public class DestructionUtil: ScriptableObject
{
    public void Destroy(GameObject gameObject) => Object.Destroy(gameObject);
}
