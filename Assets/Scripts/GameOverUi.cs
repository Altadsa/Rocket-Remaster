using TMPro;
using UnityEngine;

public class GameOverUi : MonoBehaviour
{
    [SerializeField] TMP_Text _gameScore;
    [SerializeField] TMP_Text _highScore;

    ScoreManager _scoreManager;
    SaveManager _saveManager;

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _saveManager = FindObjectOfType<SaveManager>();
    }

    public void OnGameOver()
    {
        var gameScore = _scoreManager.Score;
        var highScore = _saveManager.GameData.HighScore;

        _gameScore.text = gameScore > highScore ? $"Your Score: {gameScore} \t New Record!" : $"Your Score: {gameScore}";
        _highScore.text = gameScore > highScore ? $"High Score: {gameScore}" : $"High Score: {highScore}";
    }

}