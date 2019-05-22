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
        print(data.mapPos[0]);
        Player.transform.position = new Vector3(data.mapPos[0], data.mapPos[1], data.mapPos[2]);
        print(Player.transform.position.x);
        //  Find all nodes
        for (int i = 0; i < nodes.Count; i++)
        {
            //  If we have a manager and the current object has a node sscript, and the node is in the nodes list of the manager
            if (nodes[i] != null)
            {
                if (GetComponent<MapNodeManager>().nodes.Contains(nodes[i]))
                {
                    //  Does this object also have a combat loader?
                    if (nodes[i].gameObject.GetComponent<Combat>() != null)
                    {
                    //  If this combat is a finished one, 
                    print(nodes[i].name);
                        if (CombatInfo.CombatsFinished.Contains(nodes[i].gameObject.GetComponent<Combat>()))
                        {
                            nodes[i].nodeState = NodeState.Complete;
                            Debug.Log("We have found a node! it is done!");
                            return;
                        }
                    }
                }
            }
        }
    }


    public List<MapNode> nodes;
}
