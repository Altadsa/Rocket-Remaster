using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    RocketMovement _movement;

    Vector3 _orignalPosition;

    void Start()
    {
        _movement = new RocketMovement(transform, _moveSpeed);
        _orignalPosition = transform.position;
    }

    void Update()
    {
        _movement.Update();
    }

    public void OnGameStart()
    {
        enabled = true;
        transform.position = _orignalPosition;
    }

    public void OnGameOver()
    {
        enabled = false;
    }

}


public class RocketMovement
{
    Transform _rocket;
    float _moveSpeed = 10;

    //TODO Remove once ready
    bool _usingKeyboard = false;

    public RocketMovement(Transform rocketTransform, float speed)
    {
        _rocket = rocketTransform;
        _moveSpeed = speed;
    }

    public void Update()
    {
        if (!_usingKeyboard)
        {
            var deviceInputs = Accelerometer.Value * _moveSpeed * Time.deltaTime;
            _rocket.position += new Vector3(deviceInputs.x, 0);
        }
        else
        {
            var keyboardInputs = Input.GetAxisRaw("Horizontal") * _moveSpeed * Time.deltaTime;
            _rocket.position += new Vector3(keyboardInputs, 0);
        }
    }
}
