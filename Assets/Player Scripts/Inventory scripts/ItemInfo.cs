using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemInfo : MonoBehaviour {
    public enum ItemType {weapon, armor ,potion,other};
    public ItemType type;
    public Item item;
    private PlayerInventory playerInventory;

    public Vector3 position;
    public Vector3 rotation;

    public int damage;
    public int healValue;
    public int defense;
    void Awake ()
    {
        playerInventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerInventory>() as PlayerInventory;
        Debug.Log(playerInventory.inventory.Count);
    }
    
    void Start ()
    {
        switch (type)
        {
            case (ItemType.weapon):
            {
                item=new Weapon(item.name,item.description,item.stackable,item.value,item.modelPath,item.weight,damage,position,rotation);
                break;
            }
            case (ItemType.potion):
            {
                 item=new Potion(item.name,item.description,item.stackable,item.value,item.modelPath,item.weight,healValue);
                break;
            }
            case (ItemType.armor):
            {
                item=new Armor(item.name,item.description,item.stackable,item.value,item.modelPath,item.weight,defense);
                break;
            }
        }
        item.modelPath = "Items/" + gameObject.name;
    }
    void OnMouseDown ()
    {
        GameObject.Destroy(gameObject);
        playerInventory.inventory.Add(item);
        
    }
}
