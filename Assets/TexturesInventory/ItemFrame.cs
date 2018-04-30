using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFrame : MonoBehaviour {

	public string name;
    public int value;
    public Text nameTxt, valueTxt;
    GameObject WeaponEnd;
    public void setValues ()
    {
        nameTxt.text = name;
        valueTxt.text = value.ToString();
      
    }
     void OnMouseDown ()
    {
        Debug.Log("Probuje stworzyc item");
        WeaponEnd=GameObject.FindGameObjectWithTag("WeaponEnd");
        Resources.Load("Items/SwordBlue");
      //  playerInventory.inventory.Add(item);
        
    }

}
