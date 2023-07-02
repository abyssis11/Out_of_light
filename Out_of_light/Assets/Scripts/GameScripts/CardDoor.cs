using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDoor : MonoBehaviour
{
    [SerializeField] AudioSource doorSound;
    private Bounds colliderBounds;
    private Transform childCollider;
    private Animator animator;

    public void Start()
    {
        colliderBounds = GetComponent<Collider2D>().bounds;
        childCollider = transform.Find("Collider");
        animator = GetComponent<Animator>();

    }

    public void OpenCardDoor()
    {
        //gameObject.SetActive(false);
        // disable collider
        childCollider.GetComponent<Collider2D>().enabled = false;

        // animate door
        animator.SetTrigger("Open");
        doorSound.Play();

        // which part of graph to update
        var graphToScan = new GraphUpdateObject(colliderBounds);
        AstarPath.active.UpdateGraphs(graphToScan);
    }
}
