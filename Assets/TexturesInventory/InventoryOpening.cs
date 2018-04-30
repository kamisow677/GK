using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpening : MonoBehaviour {

	public bool opened=false;

	private GameObject inventoryPanel;
	private GameObject swordInitiated;
	GameObject WeaponEnd;
	InventoryMenu inventoryMenu;
	int i=0;
	void Awake()
	{
		
		inventoryPanel=GameObject.FindGameObjectWithTag("inventory");
		inventoryMenu = GameObject.FindGameObjectWithTag("Items").GetComponent<InventoryMenu>();
		opened=false;
		inventoryPanel.SetActive(false);
		
	}
	void Update () {

		if (Input.GetKey (KeyCode.I) && opened==false )
        {
			Debug.Log("wszedlem");
            opened=true;
			Debug.Log("otwieram inventory " +i++);
			inventoryPanel.SetActive(true);
			inventoryMenu.updateMenu();
			
        }
		if (Input.GetKey (KeyCode.O) && opened==true)
        {
			
			//WeaponEnd.transform.parent=sword2.transform;
			//WeaponEnd.transform.parent = sword2.;

			opened=false;
			Debug.Log("zamykam inventory " +i++);
			inventoryPanel.SetActive(false);
		
        }
		
	}
}
