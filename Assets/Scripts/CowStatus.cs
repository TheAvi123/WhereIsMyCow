using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct SpawnObjects
{
    public string tag;
    //public PrimitiveType spawnedObject;
    public Transform spawnPoint;
    public bool isAlive;
    //public  cowType;

}

public class CowStatus : MonoBehaviour
{
   
    public SpawnObjects cowStatus { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DeactivateCow()
    {
        SpawnObjects so = new SpawnObjects();
        so.isAlive = false;
        so.spawnPoint = cowStatus.spawnPoint;
        so.tag = cowStatus.tag;
        cowStatus = so;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
