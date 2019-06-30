using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame<T>(T saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/Data.Rocket";
        using (FileStream stream = new FileStream(savePath, FileMode.Create))
        {
            formatter.Serialize(stream, saveData);
        }
    }

    public static T LoadSave<T>()
    {
        string savePath = Application.persistentDataPath + "/Data.Rocket";
        if (File.Exists(savePath))
        {
            using (FileStream stream = new FileStream(savePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(stream);
            }
        }
        else
        {
            Debug.LogWarning("No Save data found at " + savePath);
            return default;
        }
    }
}
