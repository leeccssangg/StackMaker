using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

public class MapData : OdinMenuEditorWindow
{
    [MenuItem("Tools/Map Data")]
    private static void OpenWindow()
    {
        GetWindow<MapData>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        tree.Add("Create New Map Data", new CreateNewMapData());
        tree.AddAllAssetsAtPath("Map Data List", "Assets/Scripts/Data/Data Level", typeof(BuildData));

        return tree;
    }

    public class CreateNewMapData
    {
        public CreateNewMapData()
        {
            mapData = ScriptableObject.CreateInstance<BuildData>();

        }

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public BuildData mapData;

        [InlineButton("GenerateNewMapData", "Generate")]
        public int levelNumber;

        private void GenerateNewMapData()
        {
            AssetDatabase.CreateAsset(mapData, "Assets/Scripts/Data/Data Level/Level " + levelNumber + ".asset");
            AssetDatabase.SaveAssets();
            mapData = ScriptableObject.CreateInstance<BuildData>();
        }
    }
}
