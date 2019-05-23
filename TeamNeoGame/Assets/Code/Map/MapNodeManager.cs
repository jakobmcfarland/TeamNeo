using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeManager : MonoBehaviour
{
    static MapNodeManager instance;
    public GameObject Player;

    public List<MapNode> nodes;

    public static MapNodeManager GetInstance()
    { return instance; }

    public void Awake()
    {
        if (instance == null)
            instance = this;

        if (GameState.GetInstance().Loaded)
        { 
            MapNodeManager mapNodeManager = MapNodeManager.GetInstance();

            //Map Node Initilization
            MapNode node = mapNodeManager.nodes[0];
            node.ObjectName = "Node0";
            node.nodeState = NodeState.Start;
            node.Initilize();

            node = mapNodeManager.nodes[1];
            node.ObjectName = "Node1";
            node.Initilize();

            node = mapNodeManager.nodes[2];
            node.ObjectName = "Node2";
            node.Initilize();

            for (int i = 0; i < CombatInfo.CombatsFinished; i++)
            {
                Player.transform.position = GameState.GetInstance().Player;
               // MapNodeManager.GetInstance().nodes[i].nodeState = NodeState.Current;
            }
        }
    }
}
