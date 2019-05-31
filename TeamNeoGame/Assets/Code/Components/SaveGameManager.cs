/******************************************************************************
    Save Game Manager
    William Siauw
    This script contains the definitions for the functions to save and load the game. 
    These functions are called externally for saving and loading
******************************************************************************/

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
        //  Actually write to the file
        formatter.Serialize(stream, data);
        //  Disable combats so that combat isn't loaded automatically upon loading
        GameState.GetInstance().ReadyToBattle = false;
        Debug.Log("saved successfully");
        stream.Close();
    }
    public static void DeleteGame() {
        string filePath = Application.persistentDataPath + "/GameData.test";
        File.Delete(filePath);
    }
    public static bool LoadGame()
    {
        string filePath = Application.persistentDataPath + "/GameData.test";

        //  If there is a file at the location,
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            //  Parse the iinformation from the file
            GameData data = formatter.Deserialize(stream) as GameData;

            //  If we have valid data,
            if (data != null)
            {
                //  Properly set the needed information to the data kiaded
                CombatInfo.CombatsFinished = data.CombatsFinished;
                CombatInfo.HealthPotionCount = data.healthPotions;
                CombatInfo.CoinCount = data.coins;
                GameState.Player = new Vector3(data.mapPos[0], data.mapPos[1], data.mapPos[2]);
                GameState.GetInstance().Loaded = true;
                GameState.curHealth = data.health;
                Debug.Log("loaded successfully");
                Debug.Log(CombatInfo.CombatsFinished);
                stream.Close();
                return true;
            }
            else
                return false;
        }
        else
        {
            Debug.LogError("SAVEFILE NOT FOUND");
            return false;
        }
    }
}
