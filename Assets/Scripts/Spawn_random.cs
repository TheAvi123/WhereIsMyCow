using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpawnObjects
{
    public string tag;
    public PrimitiveType spawnedObject;
    public Transform spawnPoint;
    public bool isAlive;

}
public class Spawn_random : MonoBehaviour
{

    private List<SpawnObjects> spawns = new List<SpawnObjects>();

    private void InitSpawnObjects()
    {
        // Init small_spawns
        var smallSpawn = GameObject.FindGameObjectsWithTag("SpawnPoint_Small");
        if (smallSpawn.Length > 0 )
        {

            foreach (var e in smallSpawn)
            {
                SpawnObjects so = new SpawnObjects();
                so.tag = "small_" + e.name;
                so.spawnPoint = e.transform;
                so.isAlive = true;
                so.spawnedObject = PrimitiveType.Cube;

                spawns.Add(so);
                //GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //o.transform.position= e.transform.position;
                //o.transform.rotation = e.transform.rotation;
                //o.AddComponent<Target>();

            }

        }
    }

    public void CreateSpawnObjects()
    {
        InitSpawnObjects();
        foreach (var e in spawns)
        {
            GameObject o = GameObject.CreatePrimitive(e.spawnedObject);
            o.transform.position = e.spawnPoint.position;
            o.transform.rotation = e.spawnPoint.rotation;
            o.AddComponent<Target>();
        }
    }
    public void Start()
    {
        CreateSpawnObjects();

        foreach(var e in spawns)
        {
            print(e.tag);
        }
    }
}
