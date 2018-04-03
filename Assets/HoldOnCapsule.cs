using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldOnCapsule : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Vector3 hitDirection = other.transform.position - transform.position;
        hitDirection = hitDirection.normalized;
        FindObjectOfType<Player_motion>().KnockBack(hitDirection);

    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
