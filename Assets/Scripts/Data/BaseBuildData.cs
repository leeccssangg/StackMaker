using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseBuildData
{
    public BuildType type;
    public Vector3 pos;
}
public enum BuildType
{
    WALL,
    EATABLE,
    UNEATABLE,
    CORNER_WALL,
    START_POINT,
    FINISH_POINT,
}

