using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAIOLD : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float nextWaypointDistance = 3f;
    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        body = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 1f);

    }
    private void Update()
    {
        /*if (PlayerController.ExitedStartRoom())
        {
            InvokeRepeating("UpdatePath", 0f, 1f);
        }*/
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(body.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) return;

        // check if we reached end of path
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
        {
            reachedEndOfPath = false;
        }

        // vector from current position to target
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - body.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;
        
        body.AddForce(force);

        // distanc to the next waypoint
        float distance = Vector2.Distance(body.position, path.vectorPath[currentWaypoint]);

        // moving to the next waypoint
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
