using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float collisionOffset = 0.01f;
    public ContactFilter2D contactFilter;
    private static bool outOfStartRoom = false;
    private Vector2 input;
    private Rigidbody2D body;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        // looking at mouse
        LookAtMouse();
        // moving
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void FixedUpdate()
    {
        // if player tries to move
        if (input != Vector2.zero)
        {
            // check for collisions
            bool move = TryToMove(input);

            // for sliding when colliding diagonally
            if (!move)
            {
                move = TryToMove(new Vector2(input.x, 0));

                if (!move)
                {
                    move = TryToMove(new Vector2(0, input.y));
                }
            }
        }
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector3)(mousePos - new Vector2(transform.position.x, transform.position.y));
    }

    private bool TryToMove(Vector2 direction)
    {
        // check for collisions
        int count = body.Cast(direction, contactFilter, castCollisions, speed * Time.fixedDeltaTime + collisionOffset);

        // if there are no collisions move
        if (count == 0)
        {
            body.MovePosition(body.position + direction.normalized * speed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "StartRoomExit") 
        {
            Debug.Log("out");
            outOfStartRoom = true;
        }
    }

    public static bool ExitedStartRoom()
    {
        return outOfStartRoom;
    }
}
