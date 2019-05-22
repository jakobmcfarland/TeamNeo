using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeManager : MonoBehaviour
{
    static MapNodeManager instance;
    public GameObject Player;
    public static MapNodeManager GetInstance()
    { return instance; }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        if(GameState.GetInstance().Loaded)
            for (int i = 0; i < CombatInfo.CombatsFinished; i++)
            {
                Player.transform.position = GameState.GetInstance().Player;
                MapNodeManager.GetInstance().nodes[i].nodeState = NodeState.Current;
            }
    }


    public List<MapNode> nodes;
}
