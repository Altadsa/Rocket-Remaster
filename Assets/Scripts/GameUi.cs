using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUi : MonoBehaviour
{
    [SerializeField] TMP_Text _score;

    ScoreManager _scoreManager;

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        _score.text = ((int) _scoreManager.Score).ToString();
    }
}