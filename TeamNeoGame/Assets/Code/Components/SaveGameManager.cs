using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveGameManager
{
    public static void SaveGame(Vector3 position, int combatsFinished)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/GameData.test";
        FileStream stream = new FileStream(filePath, FileMode.Create);

        GameData data = new GameData(position, combatsFinished);
            formatter.Serialize(stream, data);
        GameState.GetInstance().ReadyToBattle = false;
        stream.Close();
    }

    public static void LoadGame()
    {
        string filePath = Application.persistentDataPath + "/GameData.test";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            CombatInfo.CombatsFinished = data.CombatsFinished;
            if (data != null)
            {
                GameState.GetInstance().Player = new Vector3(data.mapPos[0], data.mapPos[1], data.mapPos[2]);
                GameState.GetInstance().Loaded = true;
            }
            stream.Close();

        }
        else
        {
            Debug.LogError("SAVEFILE NOT FOUND");
        }
    }
}
