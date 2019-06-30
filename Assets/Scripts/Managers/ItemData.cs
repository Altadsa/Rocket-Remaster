using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Rocket Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] int _id;
    [SerializeField] Sprite _icon;

    public int Id => _id;
    public Sprite Icon => _icon;

}