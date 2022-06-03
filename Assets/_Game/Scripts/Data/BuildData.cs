using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewGameLevel", menuName = "New Game Level")]
public class BuildData : ScriptableObject
{
    [SerializeField]
    public List<BaseBuildData> builds = new List<BaseBuildData>();

    public void ClearBuildList()
    {
        builds.Clear();
    }

    public void AddBuildData(SaveLevelObject levelObject)
    {
        BaseBuildData buildData = new BaseBuildData(levelObject);
        builds.Add(buildData);
    }
}
