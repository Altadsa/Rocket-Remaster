using GEV;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] ScriptableEvent _gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rocket = collision.GetComponent<RocketController>();
        if (rocket)
        {
            _gameOver.Raise();
        }
    }
}