using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public bool pathExists = false; 
    

    // Use this for initialization
    void Start()
    {
        if (!pathExists)
        {
            Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
            List<Waypoint> path = pathfinder.GetPath();
            StartCoroutine(FollowPath(path));
            pathExists = true; 
        }
        else
        {
            //do nothing
        }
    }


    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting block: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol.");
    }

    // Update is called once per frame
    void Update () 
    {
		
	}
}
