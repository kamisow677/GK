using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackController : MonoBehaviour {

    public int damage;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("!!");
		
	}


    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name == "Player") {

            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }

    }

    
}
