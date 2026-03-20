using UnityEngine;

public enum ItemType
    {Item, Soul, Material, Weapon} 
public enum ItemRarity
    {Common, Uncommon, Rare, Epic, Legendary}

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public ItemType itemType;
    
    [Header("Item Rarity")]

    public ItemRarity itemRarity;
    
    [Header("Item Info")]
    public string itemName;
    public int itemID;
    public string itemDescription;
    public Sprite itemImage;
    public bool isPickedUp;
}
