using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour {

	public Transform Player_cam,Center_point;
	public float distance, height, orbiting_speed,vertical_speed,max_height,min_height,scroll_speed;
	private Vector3 dest;
	RaycastHit hit;
	void Update(){
		Center_point.position=gameObject.transform.position+new Vector3(0,1.5f,0);
		Center_point.eulerAngles+=new Vector3(0,Input.GetAxis("Mouse X")*orbiting_speed,0);
		height=Mathf.Clamp (height,min_height,max_height);
		height+=Input.GetAxis("Mouse Y")*Time.deltaTime*-vertical_speed;
		distance-=Input.GetAxis("Mouse ScrollWheel")*Time.deltaTime*scroll_speed;
	}
	void LateUpdate(){
		dest=Center_point.position+Center_point.forward*-1*distance+Vector3.up*height;

		if (Physics.Linecast (Center_point.position,dest,out hit)){
			//Debug.Log("camera Colision");
			if (hit.collider.CompareTag("Terrain")){
				Player_cam.position=hit.point+hit.normal*0.30f;
			}
		}
		else
			Player_cam.position=Vector3.Lerp(Player_cam.position,dest,Time.deltaTime*100);

		//Player_cam.position=Center_point.position+Center_point.forward*-1*distance+Vector3.up*height;
		Player_cam.LookAt (Center_point);
	}
}
