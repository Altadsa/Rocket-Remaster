using UnityEngine;

public class WorldBounds : MonoBehaviour
{
    RocketController _rocket;
    [SerializeField]
    Transform _left, _right;

    private void Awake()
    {
        _rocket = FindObjectOfType<RocketController>();
    }

    private void Update()
    {
        if (!_rocket) return;

        var postion = _rocket.transform.position;
        if (postion.x < _left.position.x)
            _rocket.transform.position = new Vector2(_right.position.x, postion.y);
        if (postion.x > _right.position.x)
            _rocket.transform.position = new Vector2(_left.position.x, postion.y);
    }

}
