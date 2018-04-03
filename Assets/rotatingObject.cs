using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingObject : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0f, 1f, 0f);

       // transform.Translate(0.1f, 0f, 0f);
    }
}
