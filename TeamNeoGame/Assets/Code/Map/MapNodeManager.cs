/* File:    MapNodeList
 * By:      Jakob McFarland and William Siauw
 * Brief:
 *      manages the nodes (activation and deactivation)
 */
using System.Collections;
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
        for (int i = 0; i < CombatInfo.CombatsFinished; i++)
        {
            Debug.Log(MapNodeList.nodes[i].nodeName);
            Debug.Log(MapNodeList.nodes[i].nodeState);
            MapNodeList.nodes[i].nodeState = NodeState.Complete;
            MapNodeList.nodes[i].CheckSp();
        }
        if (CombatInfo.CombatsFinished > 0)
        {
            MapNodeList.nodes[CombatInfo.CombatsFinished - 1].nodeState = NodeState.Current;
            MapNodeList.nodes[CombatInfo.CombatsFinished].nodeState = NodeState.Incomplete;
        }
        else
            ResetGame();
    }
    public static void ResetGame()
    {
        MapNodeList.nodes[0].nodeState = NodeState.Start;
        MapNodeList.nodes[1].nodeState = NodeState.Incomplete;
        MapNodeList.nodes[2].nodeState = NodeState.Start;

    }
}
