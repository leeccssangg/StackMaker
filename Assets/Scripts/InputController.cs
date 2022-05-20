using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private Joystick jt;
    [SerializeField]
    private Transform cube;

    private bool isMoveing;

    public void Start()
    {
        isMoveing = false;
    }

    public void Update()
    {
        if (!isMoveing)
        {
            GetDir(jt.Direction);          
        }
       
    }

    //Get joystick direction then checkif can move
    private void GetDir(Vector2 curDir)
    {
        float x = curDir.x;
        float y = curDir.y;
        Vector3 curTrans = cube.position - new Vector3(0, 0.25f, 0);
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
            {
                CheckMove(Vector3.right, curTrans);
            }
            else
            {
                CheckMove(Vector3.left, curTrans);
            }
        }
        else if (Mathf.Abs(x) < Mathf.Abs(y))
        {
            if (y > 0)
            {
                CheckMove(Vector3.forward, curTrans);
            }
            else
            {
                CheckMove(Vector3.back, curTrans);
            }
        }
        else
            return;
    }

    //Check target direction && target tag then move
    public void CheckMove(Vector3 tarDir, Vector3 curTrans)
    {
        RaycastHit hit;
        if (Physics.Raycast(curTrans, tarDir, out hit))
        {
            string tmp = hit.transform.gameObject.tag;
            switch (tmp)
            {
                case "FinishPoint":

                case "CheckPoint":

                case "StartPoint":

                case "Uneatable":

                case "LastCheckPoint":
                    isMoveing = true;
                    cube.DOMove(hit.transform.position, 0.5f).OnComplete(() => {
                        isMoveing = false;
                    });
                    break;
                default:
                    break;

            }    
        }
    }
    

}
