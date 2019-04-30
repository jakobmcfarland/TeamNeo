using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Incomplete,
    Complete,
    Current
}

public class MapNode : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Color incompleteNormalColor = Color.white;
    public Color completeNormalColor = new Color(0.35f, 0.35f, 0.35f);
    public Color currentNormalColor = Color.blue;
    public Color overColor = Color.grey;
    public Color downColor = new Color(0.35f, 0.35f, 0.35f);

    public MapNode previusObjectA;
    public MapNode previusObjectB;

    public MapNode previusNodeA;
    public MapNode previusNodeB;

    public NodeState nodeState = NodeState.Incomplete;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        previusNodeA = previusObjectA.GetComponent<MapNode>();
        previusNodeB = previusObjectB.GetComponent<MapNode>();

        if (nodeState == NodeState.Current) spriteRenderer.color = currentNormalColor;
    }

    void OnMouseEnter()
    {
        if(previusNodeA.nodeState == NodeState.Current) spriteRenderer.color = overColor;
    }

    void OnMouseExit()
    {
        if (previusNodeA.nodeState == NodeState.Current) spriteRenderer.color = incompleteNormalColor;
    }

    // Update when down
    void OnMouseDown()
    {
        if (previusNodeA.nodeState == NodeState.Current) spriteRenderer.color = downColor;
    }

    // Update when clicked
    void OnMouseUpAsButton()
    {
        if (nodeState == NodeState.Incomplete &&
            ( previusNodeA.nodeState == NodeState.Current
            || previusNodeB.nodeState == NodeState.Current))
        {
            ActivateNode();
        }
    }

    void ActivateNode()
    {
        spriteRenderer.color = currentNormalColor;
        nodeState = NodeState.Current;

        previusNodeA.spriteRenderer.color = completeNormalColor;
        previusNodeB.spriteRenderer.color = completeNormalColor;
        previusNodeA.nodeState = NodeState.Complete;
        previusNodeB.nodeState = NodeState.Complete;
    }
}
