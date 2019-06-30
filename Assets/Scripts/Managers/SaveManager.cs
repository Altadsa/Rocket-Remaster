using UnityEngine;

public class SaveManager : MonoBehaviour
{
    StarManager _starManager;
    ScoreManager _scoreManager;

    public PlayerData GameData {get; private set;}

    private void Awake()
    {
        _starManager = FindObjectOfType<StarManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        var saveData = SaveSystem.LoadSave<PlayerData>();
        GameData = saveData ?? new PlayerData(0, 0);
    }

    public void Save()
    {
        var stars = _starManager.Stars;
        var highScore = _scoreManager.Score > GameData.HighScore ? _scoreManager.Score : GameData.HighScore;
        GameData = new PlayerData(stars, highScore);
        SaveSystem.SaveGame(GameData);
    }

}

[System.Serializable]
public class PlayerData
{
    public int Stars { get; private set; }
    public float HighScore { get; private set; }
    public int[] UnlockedSkins { get; private set; }

    public PlayerData(int stars, float highScore)
    {
        Stars = stars;
        HighScore = highScore;
    }
}

