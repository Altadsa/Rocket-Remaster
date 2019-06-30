using System;
using UnityEngine;

public abstract class RocketItem : MonoBehaviour
{
    [SerializeField] ItemData _itemData;
    protected static RocketController _rocket;

    public ItemData Data => _itemData;
    public event Action<RocketItem> OnItemInactive;

    public abstract int ItemRemainder { get; }

    protected void Awake()
    {
        if (!_rocket) _rocket = FindObjectOfType<RocketController>();
    }

    private void OnDisable()
    {
        OnItemInactive?.Invoke(this);
    }
}