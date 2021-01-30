using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private Transform objectPos;

    [SerializeField]
    private GameObject ob;

    [SerializeField]
    private float spawnTimeLimit = 3f;
    //private GameObject;
    // Start is called before the first frame update
    private void Awake()
    {
        objectPos = gameObject.transform;
    }
    private bool CheckSpawnTime()
    {
        return Time.time >= spawnTimeLimit;
    }

    private void SpawnObject()
    {

        spawnTimeLimit += Time.time;
        Instantiate(ob, objectPos.position,Quaternion.identity); 
    }
 
    // Update is called once per frame
    void Update()
    {
        if (CheckSpawnTime())
        {
            SpawnObject();
        }
    }
}
