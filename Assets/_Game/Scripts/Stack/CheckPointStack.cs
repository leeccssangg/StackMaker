using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointStack : Stack
{
    [SerializeField]
    private Material fade;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            gameObject.GetComponent<MeshRenderer>().material = fade;
            gameObject.tag = Constant.TAG_LAST_CHECKPOINT;
        }
    }
}
