using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] AudioSource heartBeat;
    [SerializeField] private Animator animator;
    public float speed = 1f;
    public float collisionOffset = 0.01f;
    public ContactFilter2D contactFilter;
    private static bool outOfStartRoom = false;
    private Vector2 input;
    private Rigidbody2D body;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private float enemyDistance;
    private SaveObject saveObject;


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
        animator.SetBool("running", input != Vector2.zero);
        enemyDistance = Vector2.Distance(transform.position, enemy.transform.position);
        //Debug.Log(enemyDistance);

        if (enemyDistance >= 15f)
        {
            heartBeat.pitch = 1f;
        }
        else if (enemyDistance >= 11f)
        {
            heartBeat.pitch = 1.2f;
        }
        else if (enemyDistance >= 7f)
        {
            heartBeat.pitch = 1.4f;
        }
        else if(enemyDistance >= 5f)
        {
            heartBeat.pitch = 1.6f;
        }
        else if (enemyDistance >= 2.6f)
        {
            heartBeat.pitch = 1.8f;
        }
        else
        {
            heartBeat.pitch = 2f;
        }


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
        else if (collision.name == "Enemy")
        {
            GameValues.currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(8);
        } else if (collision.name == "NextLevel") {
            Debug.Log("Finished level " + (SceneManager.GetActiveScene().buildIndex-1));
            if (SceneManager.GetActiveScene().buildIndex < 7)
            {
                Debug.Log("Saving");
                SaveData(SceneManager.GetActiveScene().buildIndex);
            }
            Invoke("nextLevel", 1.5f);
        }
    }

    public void nextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static bool ExitedStartRoom()
    {
        return outOfStartRoom;
    }

    private void SaveData(int level)
    {
        // load exsisting data if exists
        if(File.Exists(Application.dataPath + "/save.txt"))
        {
            saveObject = LoadData();
        }
        else
        {
            saveObject = new SaveObject();
        }

        // add new level
        switch (level)
        {
            case 2:
                saveObject.level2 = true;
                break;
            case 3:
                saveObject.level3 = true;
                break;
            case 4:
                saveObject.level4 = true;
                break;
            case 5:
                saveObject.level5 = true;
                break;
            default:
                break;
        }

        // save to file
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }

    private SaveObject LoadData()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt"); 
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
        return saveObject;
    }
    
}
