using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public Transform door;

    public Vector3 closedPosition = new Vector3(.51f, 3.63f, 0);
    public Vector3 openPosition = new Vector3(.51f, 7, 0);

    public float openSpeed = 5;
    private bool open = false;

	
	// Update is called once per frame
	void Update () {

        if (open)
        {
            door.position = Vector3.Lerp(door.position, openPosition, Time.deltaTime * openSpeed);
        }
        else {
            door.position = Vector3.Lerp(door.position, closedPosition, Time.deltaTime * openSpeed);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseDoor();
        }
    }

    public void CloseDoor()
    {
        open = false;
    }

    public void OpenDoor()
    {
        open = true;
    }

}
