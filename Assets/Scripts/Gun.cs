using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject prefabBullet;
    public Transform startingPos;
    public float bulletSpeed;
    public Camera fpsCam;
    public float range = 100.0f;
    public float damageAmount = 20.0f;
    public GameObject flare;

    void FireBullet()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target t = hit.transform.GetComponent<Target>();
            if (t != null)
            {
                t.TakeDamage(damageAmount);
            }
            // Debug.Log(hit.transform.name);
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
    }
}
