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
                MapNodeList.nodes[i].nodeState = NodeState.Current;
            }
        //}     
    }
}
