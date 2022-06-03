using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseBuildData
{
    //public BaseBuildData();
    public BaseBuildData(SaveLevelObject levelObject)
    {
        this.type = levelObject.type;
        this.pos = levelObject.transform.position;
    }
    public LevelObjectType type;
    public Vector3 pos;
}


