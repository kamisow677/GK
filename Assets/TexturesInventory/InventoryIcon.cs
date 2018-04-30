using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryIcon : MonoBehaviour {
	Image image;
	// Use this for initialization
	void Awake () {
		image = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	public void changeColor(Color color)
	{
		color.a=1;
		image.color=color;
		
	}
}
