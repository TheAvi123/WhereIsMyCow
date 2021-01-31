using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    private Transform startingPos;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private Camera fpsCam;
    [SerializeField]
    private float range = 100.0f;
    [SerializeField]
    private float damageAmount = 20.0f;
    [SerializeField]
    private GameObject flare;

    void FireBullet()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target t = hit.transform.GetComponent<Target>();
            if (t != null)
            {
                t.TakeDamage(damageAmount,ref t);
            }
             Debug.Log(hit.transform.name);
            GameObject flareAffect = Instantiate(flare, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(flareAffect, 0.2f);
            
        }
        GameObject bullet = Instantiate(prefabBullet) as GameObject;
        bullet.transform.position = startingPos.position;
        //print("Parent Z: "+ transform.parent.position.z.ToString());
        //print("object: "+ startingPos.position.z);
        //bullet.GetComponent<Rigidbody>().velocity = (transform.TransformDirection (Vector3.forward)) * bulletSpeed;
        bullet.GetComponent<Rigidbody>().velocity = (transform.parent.forward) * bulletSpeed;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void DestroyBullet()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        foreach(var b in bullets)
        {
            if(Vector3.Distance(startingPos.position, b.GetComponent<Transform>().position) >= 90f)
            {
                Destroy(b);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsInvoking("FireBullet"))
            {
                InvokeRepeating("FireBullet", 0.0f, 2.5f);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            CancelInvoke("FireBullet");
        }

        DestroyBullet();
    }
}
