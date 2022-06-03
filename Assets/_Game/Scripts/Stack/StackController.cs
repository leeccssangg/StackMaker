using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private Transform model;
    private int count;
    private Stack<GameObject> stacks;
    private float startPosY;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        stacks = new Stack<GameObject>();
        startPosY = model.position.y;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        string tmp = other.tag;
        switch (tmp)
        {
            case Constant.TAG_EATABLE:

            case Constant.TAG_CHECK_POINT:
                EatStack();
                break;
            case Constant.TAG_UNEATABLE:
                SpawnStack(other.transform.position);
                break;
            case Constant.TAG_FINISH_POINT:
                ClearAllStack();
                break;
            default:
                break;

        }
    }

    private void EatStack()
    {
        count++;
        model.position += new Vector3(0, 0.2f, 0);
        GameObject tmpStack = Instantiate(cube, transform.position + new Vector3(0, 0.2f* count, 0), Quaternion.identity, this.transform);
        stacks.Push(tmpStack);
       
    }

    private void SpawnStack(Vector3 spawnPos)
    {
        GameObject tmpStack = stacks.Pop();
        tmpStack.transform.parent = null;
        tmpStack.transform.position = spawnPos;
        model.position -= new Vector3(0, 0.2f, 0);
        count--;
    }

    private void ClearAllStack()
    {
        foreach(GameObject s in stacks)
        {
            Destroy(s);
        }
        model.position = new Vector3(model.position.x, startPosY, model.position.z);
    }
}
