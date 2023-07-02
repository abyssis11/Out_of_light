using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] AudioSource cardSound;
    [SerializeField] AudioSource electricSound;
    private GameObject[] cardDoors;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            cardSound.Play();
            electricSound.Pause();
            cardDoors = GameObject.FindGameObjectsWithTag("CardDoor");
            foreach (GameObject cardDoor in cardDoors)
            {
                cardDoor.GetComponent<CardDoor>().OpenCardDoor();
            }
            Destroy(gameObject,1);
        }
    }
}
