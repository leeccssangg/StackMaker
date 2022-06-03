using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelObject : MonoBehaviour
{
    public LevelObjectType type;
}

public enum LevelObjectType
{
    WALL,
    EATABLE,
    UNEATABLE,
    CORNER_WALL,
    CHECK_POINT,
    START_POINT,
    FINISH_POINT,
}