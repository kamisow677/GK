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
		Debug.Log(Input.GetAxis ("Fire1"));
		if (Input.GetAxis ("Fire1")>0.1)
        {
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("idleWeap")||anim.GetCurrentAnimatorStateInfo (0).IsTag ("walkingWeap"))
            anim.SetBool ("attackingWeapon",true);
        }
		
	}
	public void displayWeapon() {
		
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
