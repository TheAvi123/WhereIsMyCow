using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn_random : MonoBehaviour
{

   
    [SerializeField]
    private List<Transform> cowLocations;
    [SerializeField]
    private List<GameObject> cowPrefabs;


    public void KillObject(string objectTag)
    {
   
    }
    public void CreateSpawnObjects()
    {

        foreach (var e in cowLocations)
        {
            GameObject o = Instantiate(cowPrefabs[Random.Range(0,cowPrefabs.Count)],e.position,e.rotation);
            SpawnObjects so = new SpawnObjects();
            so.tag = "Spawnpoint_Small_" + e.name;
            so.isCaptured = false;
            so.spawnPoint = e.transform;
           // CowStatus cs = o.AddComponent<CowStatus>();
           // cs.cowStatus = so;
            o.AddComponent<Target>();
           
            
        }
    }

    public void Start()
    {
        CreateSpawnObjects();
   
    }
    public void Update()
    {
        //foreach (var e in cowLocations)
        //{
        //    //GameObject o = Instantiate(cowPrefabs[Random.Range(0, cowPrefabs.Count)], e.position, e.rotation);
        //    //SpawnObjects so = new SpawnObjects();
        //    //so.tag = "Spawnpoint_Small_" + e.name;
        //    //so.isAlive = true;
        //    //so.spawnPoint = e.transform;
        //    //CowStatus cs = o.AddComponent<CowStatus>();
        //    //cs.cowStatus = so;
        //    //o.AddComponent<Target>();

        //}
    }
}
