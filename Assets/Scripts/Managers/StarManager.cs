using UnityEngine;

public class StarManager : MonoBehaviour
{
    SaveManager _saveManager;

    public int Stars { get; private set; } = 0;

    private void Start()
    {
        _saveManager = FindObjectOfType<SaveManager>();
        Stars = _saveManager.GameData.Stars;
    }

    //TODO ADD, REMOVE, SAVE

    public void AddStar()
    {
        Stars++;
    }

    public void RemoveStars(int amount)
    {
        Stars -= amount;
    }

}

