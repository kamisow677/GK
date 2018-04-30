using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

	public string description;
	public string name;
	public int value;
	public bool stackable;
	public string modelPath;
	public int weight;
	public Item(string name,string description,bool stackable, int value, string modelPath, int weight)
	{
		this.description=description;
		this.name=name;
		this.stackable=stackable;
		this.value=value;
		this.modelPath=modelPath;
		this.weight=weight;
	}
}
[System.Serializable]
public class Weapon: Item 
{
	public int damage;
	public Vector3 rotation;
	public Vector3 position;

	public Weapon(string name,string description,bool stackable, int value,string modelPath,int weight,int damage, Vector3 position, Vector3 rotation)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.rotation=rotation;
		this.position=position;
		this.damage=damage;
	}
}
[System.Serializable]
public class Potion: Item 
{
	public int healValue;
	public Potion(string name,string description,bool stackable, int value,string modelPath,int weight,int healValue)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.healValue=healValue;
	}
}
[System.Serializable]
public class Armor: Item 
{
	public int defense;
	public Armor(string name,string description,bool stackable, int value,string modelPath,int weight,int defense)
		:base(name,description,stackable,value,modelPath,weight)
	{
		this.defense=defense;
	}
}
[System.Serializable]
public class InventoryData
{
	public List<Item> items;
}
