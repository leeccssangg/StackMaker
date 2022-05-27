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

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        stacks = new Stack<GameObject>();
    }

    public void OnTriggerEnter(Collider other)
    {
        
        string tmp = other.tag;
        //switch (tmp)
        //{
        //    case Constant.TAG_EATABLE:

        //    case Constant.TAG_CHECK_POINT:
        //        EatStack();
        //        break;
        //    case Constant.TAG_UNEATABLE:
        //        SpawnStack(other.transform.position);
        //        break;
        //    case Constant.TAG_FINISH_POINT:

        //    default:
        //        break;

        //}
        if (tmp.Equals(Constant.TAG_EATABLE) || tmp.Equals(Constant.TAG_CHECK_POINT))
        {
            Debug.Log("player c" + other.name);
            EatStack();
        }
        if (tmp.Equals(Constant.TAG_UNEATABLE))
        {
            SpawnStack(other.transform.position);
        }
        if (tmp.Equals(Constant.TAG_FINISH_POINT))
        {

        }
    }

    private void EatStack()
    {
        count++;
        model.position += new Vector3(0, 1, 0);
        GameObject tmpStack = Instantiate(cube, transform.position + new Vector3(0, 1* count, 0), Quaternion.identity, this.transform);
        stacks.Push(tmpStack);
       
    }

    private void SpawnStack(Vector3 spawnPos)
    {
        GameObject tmpStack = stacks.Pop();
        tmpStack.transform.parent = null;
        tmpStack.transform.position = spawnPos;
        model.position -= new Vector3(0, 1, 0);
        count--;
    }
}
