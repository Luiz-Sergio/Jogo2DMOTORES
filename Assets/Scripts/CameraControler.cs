using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float beforex;
    private float afterx;
    private float beforey;
    private float aftery;

    void Start()
    {
        beforex = player.position.x;
        beforey = player.position.y;

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
    void Update()
    {
        afterx = player.position.x;
        aftery = player.position.y;
        float diffx = transform.position.x - player.position.x;
        float diffy = transform.position.y - player.position.y;

        if (diffx > -3 && diffx<3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + (afterx-beforex), transform.position.y, transform.position.z);

        }

        if (diffy < -2.6f || diffy >0)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y + (aftery - beforey), transform.position.z);

        }

        beforex = afterx;
        beforey = aftery;

        
    }
}
