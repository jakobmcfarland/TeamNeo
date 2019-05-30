using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Map
{
    class MapNodeComponent : MonoBehaviour
    {
        public int nodeIndex = -1;
        public MapNode mapNode;

        void Start()
        {
            if (nodeIndex >= 0 && nodeIndex < MapNodeList.nodes.Count())
            {             
                mapNode = MapNodeList.nodes[nodeIndex];
                mapNode.Init(gameObject);
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (mapNode != null)
            {
                mapNode.ActivateNode(col.gameObject);
            } else {
                print("null");
            }
        }
    }
}
