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
        MapNode mapNode;

        void OnCollisionEnter2D(Collision2D col)
        {
            mapNode.ActivateNode(col.collider);
        }
    }
}
