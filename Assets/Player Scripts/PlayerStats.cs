using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int hitpoints;
    public Text hpGUI;

	// Use this for initialization
	void Start () {       
    }
	
	// Update is called once per frame
	void Update () {
        hpGUI.text = "HP: " + hitpoints;
	}

    public void TakeDamage(int damage)
    {
        hitpoints -= damage;
    }

}

