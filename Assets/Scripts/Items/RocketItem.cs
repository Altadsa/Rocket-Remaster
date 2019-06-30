using UnityEngine;

public abstract class RocketItem : MonoBehaviour
{
    protected static RocketController _rocket;

    protected void Awake()
    {
        if (!_rocket) _rocket = FindObjectOfType<RocketController>();
    }
}