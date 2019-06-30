using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    const int FACTOR = 25;

    SaveManager _saveManager;
    public float Score { get; private set; } = 0;

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            Score += Time.deltaTime * FACTOR;
            yield return new WaitForEndOfFrame();
        }
    }

    public void OnGameStart()
    {
        Score = 0;
        StartCoroutine(IncreaseScore());
    }

    public void OnGameEnd()
    {
        StopAllCoroutines();
    }
}
