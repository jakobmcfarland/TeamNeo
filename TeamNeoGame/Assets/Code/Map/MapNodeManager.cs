using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeManager : MonoBehaviour
{
    public GameObject Player = null;
    [HideInInspector]
    public bool ReadyToBattle = false;

    static MapNodeManager instance;
    public static MapNodeManager GetInstance()
    { return instance; }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        GameData data = SaveGameManager.LoadGame();
        CombatInfo.CombatsFinished = data.CombatsFinished;
        if (data != null)
        {
            Player.transform.position = new Vector3(data.mapPos[0], data.mapPos[1], data.mapPos[2]);

            for (int i = 0; i < CombatInfo.CombatsFinished; i++)
            {
                MapNodeManager.GetInstance().nodes[i].nodeState = NodeState.Current;
            }
        }
    }


    public List<MapNode> nodes;
}
