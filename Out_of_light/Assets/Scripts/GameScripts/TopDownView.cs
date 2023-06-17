using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownView : MonoBehaviour
{
    [SerializeField] public GameObject tilePrefab;
    [SerializeField] public GameObject wallPrefab;
    private GameObject wall;
    // Start is called before the first frame update
    void Start()
    {

        for (int i=0; i<25; i++)
        {
            for(int j=0; j<25; j++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(i,j,1),  Quaternion.identity);
            }
        };
        //Horizontal walls
        for (int i=0; i<25;i++)
        {
            wall = Instantiate(wallPrefab,new Vector3(i,-1,0),  Quaternion.identity);
            wall = Instantiate(wallPrefab,new Vector3(i,25,0),  Quaternion.identity);
        };
        //Vertical walls
        for (int i=-1;i<=25;i++)
        {
            wall = Instantiate(wallPrefab,new Vector3(-1,i,0),  Quaternion.identity);
            wall = Instantiate(wallPrefab,new Vector3(25,i,0),  Quaternion.identity);
        }; 
    }
}
