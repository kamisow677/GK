using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour {
	public List<Item> inventory=new List<Item>();
	void Start()
	{
		//inventory.Add(new Weapon("KNAJF","basic poor weapon",false,100,"Items/Dagger",1));
		//inventory.Add(new Potion("Potion of healing","basic poor healing potion",false,30,"Items/Dagger",5));
		//saveInventory();
		loadInventory();
	}	

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
                saveInventory();
        }
    }
	 public void saveInventory ()
    {
        InventoryData inventory_data = new InventoryData();
        inventory_data.items = inventory;
        IOM.save<InventoryData>(inventory_data, "player_inventory");
        Debug.Log("inventory was saved");
    }
    public void loadInventory ()
    {
        if (IOM.fileExists("player_inventory"))
        {
            inventory = IOM.load<InventoryData>("player_inventory").items;
            Debug.Log("inventory was loaded");
        }
        else
            Debug.Log("inventory was'n loaded, because there is no file");    
    }
}
