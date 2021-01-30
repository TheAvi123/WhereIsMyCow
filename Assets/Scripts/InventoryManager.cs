using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryManager Instance;
    private bool isFull = false;
    public bool IsFull { get
        {
            return isFull;
        }
        set
        {
            isFull = value;
        }
    }

    [SerializeField]
    private GameObject inventoryItemImage;
    [SerializeField]
    private GameObject inventoryEmptyText;

    private GameObject itemBeingHeld;

    void Awake()
    {
     if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public bool TryAddToInventory(GameObject objectToAdd)
    {
        if (IsFull)
        {
            //can't add to inventory - make noise    
            return false;
        }
        else
        { //add item to inventory
            isFull = true;
            inventoryItemImage.GetComponent<Image>().sprite = objectToAdd.GetComponent<Test_Cow>().spriteImage;
            inventoryEmptyText.SetActive(false);
            inventoryItemImage.SetActive(true);
            itemBeingHeld = objectToAdd;
        }
        return true;

    }
    public bool TryRemoveFromInventory(Transform destinationTransform)
    {
        if (!IsFull)
        {
            //can't remove from inventory - make noise
            return false;
        }
        else
        { // remove item from inventory
            
            inventoryEmptyText.SetActive(true);
            inventoryItemImage.SetActive(false);

            //drop game object at new position
            itemBeingHeld.transform.position = destinationTransform.position;
            itemBeingHeld.transform.Translate(0, 2, 0);
            itemBeingHeld.transform.rotation = destinationTransform.rotation;
            itemBeingHeld.SetActive(true);
            itemBeingHeld = null;
            isFull = false;
        }
        return true;
    }
}
