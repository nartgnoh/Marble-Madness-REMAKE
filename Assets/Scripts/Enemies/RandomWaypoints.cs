using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to Empty GameObject to set WayPoints for Enemy Movement
//MoveTowards waypoints at RANDOM
//Set Enemies that reset the level by attaching the "Enemies" tag to them
public class RandomWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 5f;

    int current = 0;
    float WPradius = 1;
	
	void Update () {
		if(Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current = Random.Range(0,waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }
}

