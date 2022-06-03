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
#if UNITY_EDITOR
    public void Update()
    {
        GetDir(jt.Direction);
    }


    //Get joystick direction then checkif can move
    private void GetDir(Vector2 curDir)
    {
        float x = curDir.x;
        float y = curDir.y;
        Vector3 curTrans = cube.position - new Vector3(0, 0.1f, 0);
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
#elif UNITY_ANDROID
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                GetDir(touch);
            }
        }
    }
    private void GetDir(Touch touch)
    {
        float x = touch.deltaPosition.x;
        float y = touch.deltaPosition.y;
        Vector3 curTrans = cube.position - new Vector3(0, 0.1f, 0);
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
#endif
    //Check target direction && target tag then move
    public void CheckMove(Vector3 tarDir, Vector3 curTrans)
    {
        if (!isMoveing)
        {
            RaycastHit hit;
            if (Physics.Raycast(curTrans, tarDir, out hit))
            {
                string tmp = hit.transform.gameObject.tag;
                switch (tmp)
                {
                    case Constant.TAG_FINISH_POINT:

                    case Constant.TAG_CHECK_POINT:

                    case Constant.TAG_START_POINT:

                    case Constant.TAG_UNEATABLE:

                    case Constant.TAG_LAST_CHECKPOINT:
                        isMoveing = true;
                        cube.DOMove(hit.transform.position, 1f).OnComplete(() => {
                            isMoveing = false;
                        });
                        break;
                    default:
                        break;

                }
            }
        }
    }
    

}
