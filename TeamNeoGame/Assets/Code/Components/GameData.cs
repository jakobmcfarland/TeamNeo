using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<Combat> CombatsFinished;
    public float[] mapPos;

    public GameData(Vector3 pos, List<Combat> combats)
    {
        mapPos = new float[3];
        CombatsFinished = combats;

        mapPos[0] = pos.x;
        mapPos[1] = pos.y;
        mapPos[2] = pos.z;
        mapPos[2] = pos.z;
    }
}
