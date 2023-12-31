using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDoor : MonoBehaviour
{
    [SerializeField] AudioSource doorSound;
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private Text speechText;
    private bool doorOpen = false;
    private Bounds colliderBounds;
    private Transform childCollider;
    private Animator animator;

    public void Start()
    {
        colliderBounds = GetComponent<Collider2D>().bounds;
        childCollider = transform.Find("Collider");
        animator = GetComponent<Animator>();
        speechBubble.SetActive(false);

    }

    public void OpenCardDoor()
    {
        //gameObject.SetActive(false);
        // disable collider
        childCollider.GetComponent<Collider2D>().enabled = false;

        // animate door
        animator.SetTrigger("Open");
        speechBubble.SetActive(false);
        doorOpen = true;
        doorSound.Play();

        // which part of graph to update
        var graphToScan = new GraphUpdateObject(colliderBounds);
        AstarPath.active.UpdateGraphs(graphToScan);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !doorOpen)
        {
            Debug.Log("Card door");
            speechText.text = "Find the electrical box";
            speechBubble.SetActive(true);
        }
    }
    private void LateUpdate()
    {
        speechBubble.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
