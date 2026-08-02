using UnityEngine;

public abstract  class Upgrade : ScriptableObject
{
    [Header("Upgrade Info")]
    public string upgradeName;
    [TextArea]
    public string description;
    public Sprite icon;

    public abstract void Apply(GameObject player);
}
