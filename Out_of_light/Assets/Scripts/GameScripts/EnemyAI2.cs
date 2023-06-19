using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour
{
    private AIPath pathfinder;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.ExitedStartRoom())
        {
            pathfinder.canMove = true;
        }
    }

}
