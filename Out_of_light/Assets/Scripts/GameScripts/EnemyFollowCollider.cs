using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowCollider : MonoBehaviour
{
    private EnemyAI2 parentScript;
    private int randomNmber;
    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> patrolPoints;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("follow collider");
        parentScript = transform.parent.GetComponent<EnemyAI2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("Player in range");
            parentScript.UpdateDestionation(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            randomNmber = Random.Range(0, 3);
            Debug.Log("Player in out of range");
            parentScript.UpdateDestionation(patrolPoints[randomNmber]);
        }
    }
}
