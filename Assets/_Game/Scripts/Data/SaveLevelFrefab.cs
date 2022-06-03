using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelFrefab : MonoBehaviour
{
    public SaveLevelFrefab(LevelObjectType _type)
    {
        this.type = _type;
    }
    public LevelObjectType type;
    public GameObject prefab;
}
