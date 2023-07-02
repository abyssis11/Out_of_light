using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    private AIPath pathfinder;
    [SerializeField] private Transform player;
    [SerializeField] private Transform patrolPoint1;
    [SerializeField] private Transform patrolPoint2;
    [SerializeField] private Transform patrolPoint3;
    private AIDestinationSetter destination;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<AIPath>();
        destination = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.ExitedStartRoom())
        {
            pathfinder.canMove = true;
        }

    }

    public void UpdateDestionation(Transform target)
    {
        destination.target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.name == "PatrolPoint1")
        {
            UpdateDestionation(patrolPoint2);
        }
        if (collision.name == "PatrolPoint2")
        {
            UpdateDestionation(patrolPoint3);
        }
        if (collision.name == "PatrolPoint3")
        {
            UpdateDestionation(patrolPoint1);
        }
    }

}
