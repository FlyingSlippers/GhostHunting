using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool inventoryEnabled;

    private int allSlots = 6;
    private int enabledSlots;
    private GameObject [] slot;
     
    
     public GameObject slotHolder;
    void Start()
    {
        allSlots = 6;
        slot = new GameObject[allSlots];
        for (int  i =0 ; i < allSlots;i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;

            if (slot[i].GetComponent<Slot>().itemObject == null)
            {
                slot[i].GetComponent<Slot>().isEmpty = true;
                break;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            inventoryPanel.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
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
        }

    }
}
