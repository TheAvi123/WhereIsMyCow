using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CaptureBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            InventoryManager.Instance.TryRemoveFromInventory(gameObject.transform);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.gameObject.name);
        GameObject maybeCow = c.gameObject.transform.parent.gameObject;


        if (maybeCow.tag == "cow")
        {
            //Try to add to inventory;
            if (InventoryManager.Instance.TryAddToInventory(maybeCow))
            {
                maybeCow.SetActive(false);
            }
        }
    }
}
