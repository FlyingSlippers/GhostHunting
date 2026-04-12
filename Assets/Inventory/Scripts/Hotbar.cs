using Unity.VisualScripting;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject hotbarPanel;
    private bool hotbarEnabled;

    private int allSlots = 6;
    private int enabledSlots;
    private GameObject [] slot;
    
    private Inventory inventory;
    
     public GameObject slotHolder;
    void Start()
    {
        inventory = GetComponent<Inventory>();
        allSlots = 6;
        slot = new GameObject[allSlots];
        hotbarEnabled = true;
    }

    void Update()
    {
        if (inventory.inventoryEnabled == true)
        {
            hotbarEnabled = false;
        }
        else
        {
            hotbarEnabled = true;
        }
        if (hotbarEnabled)
        {
            hotbarPanel.SetActive(true);
        }
        else
        {
            hotbarPanel.SetActive(false);
        }

        for (int  i =0 ; i < allSlots;i++)
        {
            slot[i] = slotHolder.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

            if (slot[i].GetComponent<Slot>().itemObject == null)
            {
                slot[i].GetComponent<Slot>().isEmpty = true;
                break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickup = other.gameObject;
            Item item = itemPickup.GetComponent<Item>();
            AddItem(itemPickup,item.itemType.ToString(), item.itemRarity.ToString(), item.itemName, item.itemID, item.itemImage, item.itemDescription); 
        }
    }

    void AddItem(GameObject itemObject,string itemType, string itemRarity, string itemName, int itemID, Sprite itemImage, string itemDescription)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().isEmpty)
            {
                if (itemType == "Utility" || itemType == "Soul")
                {
                     itemObject.GetComponent<Item>().isPickedUp = true;

                slot[i].GetComponent<Slot>().itemObject = itemObject;
                slot[i].GetComponent<Slot>().itemImage = itemImage;
                slot[i].GetComponent<Slot>().itemType = itemType;
                slot[i].GetComponent<Slot>().itemRarity = itemRarity;
                slot[i].GetComponent<Slot>().itemName = itemName;
                slot[i].GetComponent<Slot>().itemID = itemID;
                slot[i].GetComponent<Slot>().itemDescription = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().isEmpty = false;
                slot[i].GetComponent<Slot>().UpdateSlot();
                
                break;
                }
                else
                {
                    Debug.Log("Item type not supported");
                    break;
                }
               
            }
        }

    }
}
