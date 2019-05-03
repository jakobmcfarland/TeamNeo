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

    public Color incompleteNormalColor = new Color(1.0f, 0.0f, 0.0f, 0.5f);
    public Color completeNormalColor = new Color(0.0f, 1.0f, 0.5f, 0.5f);
    public Color currentNormalColor = new Color(0.0f, 0.5f, 0.0f, 0.5f);

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
        else spriteRenderer.color = incompleteNormalColor;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<MapPlayerController>() != null)
        {
            if (nodeState == NodeState.Incomplete &&
            (previusNodeA.nodeState == NodeState.Current
            || previusNodeB.nodeState == NodeState.Current))
            {
                ActivateNode();
            }
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
