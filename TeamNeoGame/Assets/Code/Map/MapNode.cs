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

public class MapNode : MonoBehaviour
{
    public CombatInfo.CombatInfo combatInfo;

    public SpriteRenderer spriteRenderer;

    public Color incompleteNormalColor = new Color(1.0f, 0.0f, 0.0f, 0.5f);
    public Color completeNormalColor = new Color(0.5f, 1.0f, 1.0f, 0.5f); 
    public Color currentNormalColor = new Color(0.0f, 0.5f, 0.5f, 0.5f);

    public MapNode previusObjectA;
    public MapNode previusObjectB;

    MapNode previusNodeA;
    MapNode previusNodeB;

    public NodeState nodeState = NodeState.Incomplete;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        previusNodeA = previusObjectA.GetComponent<MapNode>();
        previusNodeB = previusObjectB.GetComponent<MapNode>();

        //if (nodeState == NodeState.Start) spriteRenderer.color = currentNormalColor; else
        spriteRenderer.color = incompleteNormalColor;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<MapPlayerController>() != null)
        {
            if (nodeState == NodeState.Start
            || (nodeState == NodeState.Incomplete 
            && (previusNodeA.nodeState == NodeState.Current
            || previusNodeB.nodeState == NodeState.Current)))
            {
                ActivateNode();
            }
        }
    }

    void ActivateNode()
    {
        previusNodeA.spriteRenderer.color = completeNormalColor;
        previusNodeB.spriteRenderer.color = completeNormalColor;
        previusNodeA.nodeState = NodeState.Complete;
        previusNodeB.nodeState = NodeState.Complete;

        spriteRenderer.color = currentNormalColor;
        nodeState = NodeState.Current;

        CombatInfo.CurrentCombatInfo.CombatInfo = combatInfo;
        SceneManager.LoadScene("Combat");
    }
}
