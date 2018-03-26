using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_weapons : MonoBehaviour {

	// Use this for initialization
	Animator anim;
	public GameObject[] weapons;
	int currentWeapon=0;
	void Start () {
		 anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Z))
        {
            if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("idle"))
            {
				anim.SetBool ("equipingWeapon",true);
				displayWeapon();
			}
            else if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("idleWeap"))
			{
				anim.SetBool ("hidingWeapon",true);
				hideWeapon();
			}
        }
	}
	public void displayWeapon() {
		
		/*for (int i = 0; i < weapons.Length; i++) {
			if(weapons [i] != null)
				weapons [i].SetActive (i == currentWeapon);
		}*/
		if (weapons[currentWeapon]!=null)
			weapons[currentWeapon].SetActive(true);
		currentWeapon++;
		if(currentWeapon >= weapons.Length) {
			currentWeapon = 0;
		}	
	}
	public void hideWeapon()
	{
		if (weapons[currentWeapon]!=null)
			weapons[currentWeapon].SetActive(false);
	}
}
