using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveGameManager
{
    public static void SaveGame(Vector3 position, List<Combat> combatsFinished)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/GameData.test";
        FileStream stream = new FileStream(filePath, FileMode.Create);

        GameData data = new GameData(position, combatsFinished);
        Debug.Log (position.x);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        string filePath = Application.persistentDataPath + "/GameData.test";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("SAVEFILE NOT FOUND");
            return null;
        }
    }
}
