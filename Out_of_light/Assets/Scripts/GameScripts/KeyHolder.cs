using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keys;

    private void Awake()
    {
        keys = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        keys.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keys.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keys.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Key key = collision.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject); 
        }

        Door door = collision.GetComponent<Door>();
        if(door != null)
        {
            if(ContainsKey(door.GetKypeKey()))
            {
                door.OpenDoor();
                RemoveKey(door.GetKypeKey());
            }
        }
    }
}
