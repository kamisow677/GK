using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpening : MonoBehaviour {

	public bool opened=true;

	private GameObject inventoryPanel;
	private GameObject swordInitiated;
	GameObject WeaponEnd;
	int i=0;
	void Awake()
	{
		inventoryPanel=GameObject.FindGameObjectWithTag("inventory");
		
	}
	void Update () {

		if (Input.GetKey (KeyCode.I) && opened==false )
        {

            opened=true;
			Debug.Log("otwieram inventory " +i++);
			inventoryPanel.SetActive(true);
			
        }
		if (Input.GetKey (KeyCode.O) && opened==true)
        {
			Debug.Log("Probuje stworzyc item");
			WeaponEnd=GameObject.FindGameObjectWithTag("WeaponEnd");
			var sword=Resources.Load("Items/SwordBlue");
		    var sword2= GameObject.Instantiate(sword, WeaponEnd.transform.position, WeaponEnd.transform.rotation) as GameObject;
			sword2.transform.SetParent(WeaponEnd.transform);
			//WeaponEnd.transform.parent=sword2.transform;
			//WeaponEnd.transform.parent = sword2.;

			opened=false;
			Debug.Log("zamykam inventory " +i++);
			inventoryPanel.SetActive(false);
		
        }
		
	}
}
