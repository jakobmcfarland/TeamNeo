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
        Debug.Log(data.health);
        Debug.Log("saved");
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

            if (data != null)
            {
                CombatInfo.CombatsFinished = data.CombatsFinished;
                GameState.GetInstance().Player = new Vector3(data.mapPos[0], data.mapPos[1], data.mapPos[2]);
                GameState.GetInstance().Loaded = true;
                GameState.curHealth = data.health;
                Debug.Log(GameState.curHealth);
                CombatInfo.HealthPotionCount = data.healthPotions;
            }
            Debug.Log("loaded");
            stream.Close();

        }
        else
        {
            Debug.LogError("SAVEFILE NOT FOUND");
        }
    }
}
