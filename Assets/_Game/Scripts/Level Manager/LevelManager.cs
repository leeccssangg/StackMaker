using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;


public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private BuildData gameLevel;
    [SerializeField]
    private List<SaveLevelFrefab> prefabsList = new List<SaveLevelFrefab>();

    private void UpdateFrefabList()
    {

    }

    [ButtonGroup("LevelButtons")]
    private void LoadLevel()
    { 
        LoadCurrentLevel(gameLevel);
    }
    [ButtonGroup("LevelButtons")]
    private void SaveCurrentLevel()
    {
        SaveLevel(gameLevel);
    }
    [ButtonGroup("LevelButtons")]
    private void ClearCurrentLevel()
    {
        ClearLevel();
    }

    private void SaveLevel(BuildData level)
    {
        if(level == null)
        {
            Debug.LogError("No game level object");
            return;
        }

        level.ClearBuildList();

        SaveLevelObject[] levelObjects = FindObjectsOfType<SaveLevelObject>();

        foreach(SaveLevelObject levelObject in levelObjects)
        {
            level.AddBuildData(levelObject);
        }
    }
    
    private void LoadCurrentLevel(BuildData level)
    {
        if(level == null)
        {
            Debug.LogError("No game level object");
            return;
        }

        ClearLevel();

        foreach(BaseBuildData b in level.builds)
        {
            GameObject prefab = null;
            foreach(SaveLevelFrefab levelFrefab in prefabsList)
            {
                if(b.type == levelFrefab.type)
                {
                    prefab = levelFrefab.prefab;
                    break;
                }
            }

            if(prefab == null)
            {
                Debug.LogWarning("Couldn't find prefab of type: " + b.type.ToString());
                continue;
            }

            GameObject newInstance = Instantiate(prefab);
            newInstance.transform.position = b.pos;
        }
    }

    
    private void ClearLevel()
    {
        SaveLevelObject[] levelObjects = FindObjectsOfType<SaveLevelObject>();
        foreach(SaveLevelObject levelObject in levelObjects)
        {
            if(levelObject == null)
            {
                continue;
            }

            if (Application.isEditor)
            {
                DestroyImmediate(levelObject.gameObject);
            }

            else
                Destroy(levelObject.gameObject);
        }
    }
}
