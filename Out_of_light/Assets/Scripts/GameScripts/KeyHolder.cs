using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyHolder : MonoBehaviour
{
    [SerializeField] AudioSource collectSound;
    public event EventHandler OnKeyChanged; 
    private List<Key.KeyType> keys;

    private void Awake()
    {
        keys = new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeys() { return keys; }
    public void AddKey(Key.KeyType keyType)
    {
        keys.Add(keyType);
        OnKeyChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keys.Remove(keyType);
        OnKeyChanged?.Invoke(this, EventArgs.Empty);
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
            collectSound.Play();
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
            else if(!door.doorOpen)
            {
                door.NeedKey();
            }
        }
    }
}
