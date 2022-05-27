using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildData : ScriptableObject
{
    [Header("---------------BuildUnit------------")]
    public List<BaseBuildData> Builds;
}
