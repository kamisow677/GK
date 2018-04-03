using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_motion : MonoBehaviour {

	public Transform center_point;
    public float rotation_speed;
	bool forward, back, left, right;
    Animator anim;
	int angle_to_rotete;

    public float konckBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    void Awake () {
        anim = GetComponent <Animator> ();
    }
    void Update () {
		forward = Input.GetKey (KeyCode.W);
        back = Input.GetKey (KeyCode.S);
        left = Input.GetKey (KeyCode.A);
        right = Input.GetKey (KeyCode.D);
		angle_to_rotete=0;
		

		
        anim.SetFloat ("movement",Mathf.Max( Mathf.Abs(Input.GetAxis ("Vertical")),  Mathf.Abs(Input.GetAxis ("Horizontal"))  ));
        if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("walkingWeap"))
        {
            transform.eulerAngles += new Vector3 (0, Mathf.DeltaAngle (transform.eulerAngles.y, center_point.eulerAngles.y+angle_to_rotete) * Time.deltaTime * rotation_speed, 0);
            anim.SetFloat ("y",Input.GetAxis ("Vertical"));
            anim.SetFloat ("x",Input.GetAxis ("Horizontal"));
        }
        else
        {
        
            if (Input.GetAxis ("Jump")>0.0f)
            {
                anim.SetBool ("jumping",true);
            }
            anim.SetFloat ("movement",Mathf.Max( Mathf.Abs(Input.GetAxis ("Vertical")),  Mathf.Abs(Input.GetAxis ("Horizontal"))  ));
            if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("walking"))
            {
                calculate_angle ();
                transform.eulerAngles += new Vector3 (0, Mathf.DeltaAngle (transform.eulerAngles.y, center_point.eulerAngles.y+angle_to_rotete) * Time.deltaTime * rotation_speed, 0);
            }
        }
		
    }
	void calculate_angle () {
        if (forward && !back) {
            if (left && !right)
                angle_to_rotete = -45;
            else if (!left && right)
                angle_to_rotete = 45;
            else
                angle_to_rotete = 0;
        } 
        else if (!forward && back) {
            if (left && !right)
                angle_to_rotete = -135;
            else if (!left && right)
                angle_to_rotete = 135;
            else
                angle_to_rotete = 180;
        } 
        else {
            if (left && !right)
                angle_to_rotete = -90;
            else if (right && !left)
                angle_to_rotete = 90;
            else
                angle_to_rotete = 0;
        }
    }

    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
       Vector3 moveDirection = new Vector3 (anim.GetFloat("x"),anim.GetFloat("y"),0f);
        center_point.position = direction * 10;
        anim.SetFloat("x",direction.x*10.0f);
        anim.SetFloat("y", direction.y * 10f);
    }
}
