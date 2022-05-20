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
    [SerializeField]
    private Material fade;
    private int count;
    private Stack<GameObject> stacks;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        stacks = new Stack<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
    }

    public void OnCollisionEnter(Collision collision)
    {
        string tmp = collision.gameObject.tag;
        switch (tmp)
        {
            case "Eatable":
                collision.gameObject.SetActive(false);            
                EatStack();
                break;
            case "CheckPoint":
                collision.gameObject.GetComponent<MeshRenderer>().material = fade;
                collision.gameObject.tag = "LastCheckPoint";
                EatStack();
                break;
            case "Uneatable":
                collision.gameObject.SetActive(false);
                SpawnStack(collision.transform.position);
                break;

            case "FinishPoint":
                
            default:
                break;

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
