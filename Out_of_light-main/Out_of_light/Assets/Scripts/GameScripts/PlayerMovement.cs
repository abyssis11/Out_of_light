using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed=6.0f;
    private Vector2 input;
    void Awake()
    {
        body=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        body.velocity = input.normalized * speed;
    }
}


