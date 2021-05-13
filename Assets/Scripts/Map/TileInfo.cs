using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TileInfo
{
    public string name;
    public GameObject occupyingUnit;
    public float movementCost = 1;
    public bool isWalkable = true;
}
