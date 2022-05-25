using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableStack : Stack
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        { 
            Destroy(gameObject);
        }
    }
}
