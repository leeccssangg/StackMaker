using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UneatableStack : Stack
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            gameObject.SetActive(false);
        }
    }
}
