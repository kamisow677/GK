using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFrame : MonoBehaviour {

	public string name;
    public int value;
    public Text nameTxt, valueTxt;

    public Item item;
  
    public void setValues ()
    {
        nameTxt.text = name;
        valueTxt.text = value.ToString();
    }
    public void setNewWeapon()
	{
        if (item is Weapon)
        {
           
            Player_weapons playerWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_weapons>();
            playerWeapons.setNewWeapon((Weapon) item);
            disableFrame();
            changeColor(Color.cyan);
            
        }
	}
    public void changeColor(Color color)
	{


		color.a=1;
		Image frameImage=gameObject.GetComponent<Image>();
        frameImage.color=color;
	}
    public void disableFrame()
    {
         InventoryMenu inventoryMenu = GameObject.FindGameObjectWithTag("Items").GetComponent<InventoryMenu>();
         inventoryMenu.disableFrame();
    }
    

}
