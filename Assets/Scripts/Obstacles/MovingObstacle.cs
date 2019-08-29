using UnityEngine;

public class MovingObstacle : Obstacle
{
    [SerializeField] float _moveSpeed = 5;

    Vector3 _moveDirection;

    private void Start()
    {
        _moveDirection = Random.Range(0, 2) > 0 ? -1 * Vector3.right : 1 * Vector3.right;
    }

    private void Update()
    {
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        _moveDirection = -_moveDirection;
        Debug.Log("Trigger" + collision.name);
    }

}