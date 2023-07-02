using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        Red, Green, Blue, Orange, Purple, Brown, Yellow, Pink, White, Gray
    }

    public KeyType GetKeyType() { return keyType; }
}
