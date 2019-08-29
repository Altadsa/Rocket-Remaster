using UnityEngine;

public class StaticObstacle : Obstacle
{

    const float ROTATION_SPEED = 180;

    Vector3 _direction;

    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        _direction = Random.Range(0, 2) > 0 ? -1 * Vector3.forward : 1 * Vector3.forward;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        var angle = ROTATION_SPEED * Time.deltaTime;
        transform.Rotate(_direction, angle);
        if (transform.eulerAngles.z > 360)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

}