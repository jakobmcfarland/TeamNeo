using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum NodeState
{
    Incomplete,
    Complete,
    Current,
    Start
}

public class MapNode
{
    public string ObjectName;
    public int previusIndex;
    public NodeState nodeState = NodeState.Incomplete;

    Color incompleteNormalColor = new Color(1.0f, 0.0f, 0.0f, 0.5f);
    Color completeNormalColor = new Color(0.5f, 1.0f, 1.0f, 0.5f);
    Color currentNormalColor = new Color(0.0f, 0.5f, 0.5f, 0.5f);

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    public void Initilize()
    {
        MapNodeManager mapNodeManager = MapNodeManager.GetInstance();
        spriteRenderer = GameObject.Find(ObjectName).GetComponent<SpriteRenderer>();

        //if (nodeState == NodeState.Start) spriteRenderer.color = currentNormalColor; else
        spriteRenderer.color = incompleteNormalColor;
    }

    public void ActivateNode(Collider2D collider)
    {
        MapNodeManager mapNodeManager = MapNodeManager.GetInstance();

        if (mapNodeManager != null)
            if (collider.GetComponent<MapPlayerController>() != null && GameState.GetInstance().ReadyToBattle)
            { 
                if (nodeState == NodeState.Start
                || (nodeState == NodeState.Incomplete
                && mapNodeManager.nodes[previusIndex].nodeState == NodeState.Current))
                {
                    SaveGameManager.SaveGame(collider.transform.position, CombatInfo.CombatsFinished);

                    mapNodeManager.nodes[previusIndex].spriteRenderer.color = completeNormalColor;
                    mapNodeManager.nodes[previusIndex].nodeState = NodeState.Complete;

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
