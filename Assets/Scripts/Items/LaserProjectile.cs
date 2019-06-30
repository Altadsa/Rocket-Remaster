using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    [SerializeField] float _fireSpeed;

    const float DESPAWN_TIME = 5;
    float _elapsed = 0;

    private void Update()
    {
        _elapsed += Time.deltaTime;
        transform.position += Vector3.up * _fireSpeed * Time.deltaTime;
        if (_elapsed > DESPAWN_TIME)
        {
            _elapsed = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var obstacle = other.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacle.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}