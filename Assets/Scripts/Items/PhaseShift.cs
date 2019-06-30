using System.Collections;
using UnityEngine;

public class PhaseShift : RocketItem
{
    Collider2D _rocketCollider;

    float _duration = 10;
    float _elapsed = 0;

    public override int ItemRemainder => (int)(_duration - _elapsed);

    private new void Awake()
    {
        base.Awake();
        if (!_rocketCollider) _rocketCollider = _rocket.GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(Shift());
    }

    IEnumerator Shift()
    {
        _rocketCollider.enabled = false;
        while (_elapsed < _duration)
        {
            _elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _rocketCollider.enabled = true
            ;
        _elapsed = 0;
        gameObject.SetActive(false);
    }
}