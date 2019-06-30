using System.Collections;
using UnityEngine;

public class TimeWarp : RocketItem
{
    float _warpScale = 0.75f;

    float _duration = 10;
    float _elapsed = 0;

    public override int ItemRemainder => (int)(_duration - _elapsed);

    private void OnEnable()
    {
        StartCoroutine(WarpTime());
    }

    IEnumerator WarpTime()
    {
        Time.timeScale = _warpScale;
        while (_elapsed < _duration)
        {
            _elapsed += Time.deltaTime / _warpScale;
            yield return new WaitForEndOfFrame();
        }

        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

}