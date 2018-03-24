using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour {

	public Transform Player_cam,Center_point;
	public float distance, height, orbiting_speed,vertical_speed,max_height,min_height,scroll_speed;
	void Update(){
		Center_point.position=gameObject.transform.position+new Vector3(0,1.5f,0);
		Center_point.eulerAngles+=new Vector3(0,Input.GetAxis("Mouse X")*orbiting_speed,0);
		height=Mathf.Clamp (height,min_height,max_height);
		height+=Input.GetAxis("Mouse Y")*Time.deltaTime*-vertical_speed;
		distance-=Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime*scroll_speed;
	}
	void LateUpdate(){
		Player_cam.position=Center_point.position+Center_point.forward*-1*distance+Vector3.up*height;
		Player_cam.LookAt (Center_point);
	}
}
