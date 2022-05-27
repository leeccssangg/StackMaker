using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Joystick jt;
    private Vector3 startCameraPosition;
    private Vector3 startPlayerPosition;
    private void Start()
    {
        startPlayerPosition = player.transform.position;
        startCameraPosition = transform.position;
        jt.gameObject.SetActive(false);
        transform.DOMove(new Vector3(0f, 18f, -8.96f), 1f).OnComplete(() =>
        {    
            startPlayerPosition = player.transform.position;
            startCameraPosition = transform.position;
            jt.gameObject.SetActive(true);
        });
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }
    }
    private void FollowPlayer()
    {
        transform.position = startCameraPosition + (player.transform.position - startPlayerPosition);/* + Vector3.up * player.petCount * 0.03f + Vector3.back * player.petCount * 0.03f;*/
    }
}

