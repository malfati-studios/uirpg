using UnityEngine;

[CreateAssetMenu(fileName = "classinformation", menuName = "classinformation", order = 0)]
public class ClassInformation : ScriptableObject
{
    public string name;
    public int baseDamage;
    public int strVal;
    public int dexVal;
    public int intVal;
    public int vitVal;
}
