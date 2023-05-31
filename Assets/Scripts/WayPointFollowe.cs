using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WayPointFollowe : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private short currentWayPoint = 0;

    [SerializeField] private float speed = 2f;//velocity is 2 game units
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWayPoint].transform.position, transform.position) < .1f)
        {
            currentWayPoint++;
            if(currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPoint].transform.position, Time.deltaTime * speed);
    }
}
