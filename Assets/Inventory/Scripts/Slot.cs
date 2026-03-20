using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public GameObject itemObject;
    public string itemType;
    public string itemRarity;
    public string itemName;
    public int itemID;
    public string itemDescription;
    public bool isEmpty;
    public Sprite itemImage;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = itemImage;
    }
}
