using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Map
{
    public static class MapNodeList
    {
        public static List<MapNode> nodes = new List<MapNode>(3)
    {
        new MapNode("Node0", NodeState.Start, -1),
        new MapNode("Node1", NodeState.Incomplete, 0),
        new MapNode("Node2", NodeState.Incomplete, 1)
    };
    }
}
