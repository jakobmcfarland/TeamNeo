using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeManager : MonoBehaviour
{
    public void Awake()
    {
        GameData data = SaveGameManager.LoadGame();
            //  Find all nodes
            for (int i = 0; i < nodes.Count; i++)
            {
                print("we got a manager");
                //  If we have a manager and the current object has a node sscript, and the node is in the nodes list of the manager
                if (nodes[i] != null)
                {
                    print("axdcasd");
                    if (GetComponent<MapNodeManager>().nodes.Contains(nodes[i]))
                    {
                        print("asdas");
                        //  Does this object also have a combat loader?
                        if (nodes[i].gameObject.GetComponent<Combat>() != null)
                        {
                            print("asdasdsad");
                            //  If this combat is a finished one, 
                            if (CombatInfo.CombatsFinished.Contains(nodes[i].gameObject.GetComponent<Combat>()))
                            {
                                nodes[i].nodeState = NodeState.Complete;
                                Debug.Log("We have found a node! it is done!");
                            }
                        }
                    }
                }
                else
                    print("DIE");
            }

    }


    public List<MapNode> nodes;
}
