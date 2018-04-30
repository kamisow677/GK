using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemInfo))]
public class InspectorItemInfo : Editor {
	ItemInfo itemInfo;
	SerializedProperty description;
	SerializedProperty name;
	SerializedProperty value;
	SerializedProperty stackable;
	SerializedProperty weight;
	SerializedProperty type;
	SerializedProperty damage;
	SerializedProperty healValue;
	SerializedProperty defense;

	SerializedProperty position;
	SerializedProperty rotation;
	void OnEnable()
	{
		itemInfo=(ItemInfo) target;
		description=serializedObject.FindProperty("item.description");
		name=serializedObject.FindProperty("item.name");
		value=serializedObject.FindProperty("item.value");
		stackable=serializedObject.FindProperty("item.stackable");
		weight=serializedObject.FindProperty("item.weight");
		type=serializedObject.FindProperty("type");
		damage=serializedObject.FindProperty("damage");
		healValue=serializedObject.FindProperty("healValue");
		defense=serializedObject.FindProperty("defense");
		position=serializedObject.FindProperty("position");
		rotation=serializedObject.FindProperty("rotation");
		//itemName=serializedObject.FindProperty("item.name");
	}
	public override void OnInspectorGUI()
	{
		//base.OnInspectorGUI();
		serializedObject.Update();
		EditorGUILayout.PropertyField(type);
		EditorGUILayout.PropertyField(description);
		EditorGUILayout.PropertyField(name);
		EditorGUILayout.PropertyField(value);
		EditorGUILayout.PropertyField(stackable);
		EditorGUILayout.PropertyField(weight);
		switch(itemInfo.type)
		{
			case (ItemInfo.ItemType.weapon):
			{
				EditorGUILayout.PropertyField(damage);
				EditorGUILayout.PropertyField(position);
				EditorGUILayout.PropertyField(rotation);
				break;
			}
			case (ItemInfo.ItemType.potion):
			{
				EditorGUILayout.PropertyField(healValue);
				break;
			}
			case (ItemInfo.ItemType.armor):
			{
				EditorGUILayout.PropertyField(defense);
				break;
			}
		}
		serializedObject.ApplyModifiedProperties();
	}
}
