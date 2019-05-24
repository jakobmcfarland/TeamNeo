using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Assets.Code.Map
{
    public enum NodeState
    {
        Incomplete,
        Complete,
        Current,
        Start
    }

    public class MapNode
    {
        public string nodeName;
        public int previusIndex;
        public NodeState nodeState = NodeState.Incomplete;

        Color incompleteNormalColor = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        Color completeNormalColor = new Color(0.5f, 1.0f, 1.0f, 0.5f);
        Color currentNormalColor = new Color(0.0f, 0.5f, 0.5f, 0.5f);

        SpriteRenderer spriteRenderer;

        public MapNode(string nodeName_, NodeState nodeState_, int previusIndex_)
        {
            nodeName = nodeName_;
            nodeState = nodeState_;
            previusIndex = previusIndex_;
        }

        public void Init(GameObject nodeObj)
        {
            spriteRenderer = nodeObj.GetComponent<SpriteRenderer>();

            if  (  nodeState == NodeState.Start
                || nodeState == NodeState.Current
                || nodeState == NodeState.Complete)
            {
                spriteRenderer.color = currentNormalColor;
            }
            else
            {
                spriteRenderer.color = incompleteNormalColor;
            }
        }

        public void ActivateNode(GameObject other)
        {
            MapNodeManager mapNodeManager = MapNodeManager.GetInstance();

            //node activation
            if (mapNodeManager != null && other != null)
            {
                if (other.GetComponent<MapPlayerController>() != null && GameState.GetInstance().ReadyToBattle)
                {
                    if (nodeState == NodeState.Start
                    || (nodeState == NodeState.Incomplete
                    && MapNodeList.nodes[previusIndex].nodeState == NodeState.Current))
                    {
                        SaveGameManager.SaveGame(other.transform.position, CombatInfo.CombatsFinished);

                        if (nodeState != NodeState.Start)
                        {
                            MapNodeList.nodes[previusIndex].spriteRenderer.color = completeNormalColor;
                            MapNodeList.nodes[previusIndex].nodeState = NodeState.Complete;
                        }

                        spriteRenderer.color = currentNormalColor;
                        nodeState = NodeState.Current;

                        //get combat info from the gameobject sprite render is on
                        Combat combat = spriteRenderer.gameObject.GetComponent<Combat>();
                        if (combat != null)
                        {
                            combat.LoadCombat();
                            SceneManager.LoadScene("Combat");
                        }
                    }
                }
            }
        }
    }
}