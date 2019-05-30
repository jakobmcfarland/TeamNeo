using Assets.Code.Map;
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

        //if (GameState.GetInstance().Loaded)
        //{ 
            for (int i = 0; i < CombatInfo.CombatsFinished; i++)
            {
            Debug.Log(MapNodeList.nodes[i].nodeName);
                Debug.Log(MapNodeList.nodes[i].nodeState);
                MapNodeList.nodes[i].nodeState = NodeState.Complete;
            MapNodeList.nodes[i].CheckSp();
        }

        Debug.Log(CombatInfo.CombatsFinished);
        Debug.Log(MapNodeList.nodes[CombatInfo.CombatsFinished - 1].nodeName);

        Debug.Log(MapNodeList.nodes[CombatInfo.CombatsFinished - 1].nodeState);
        if (CombatInfo.CombatsFinished >=0)
                MapNodeList.nodes[CombatInfo.CombatsFinished-1].nodeState = NodeState.Current;

        //}     
    }
}
