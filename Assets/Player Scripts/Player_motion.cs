using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_motion : MonoBehaviour {

	public Transform center_point;
    public Transform Player_cam;
    private Transform center;
    private float kat;
    public float rotation_speed;
	bool forward, back, left, right;
    private bool JUMPING=false;
    Animator anim;
    Rigidbody rb;
    //private CharacterController controller;
	int angle_to_rotete;

    private float gravity=5*14.0f;
    private float jumpforce=0.6f;
    private float verticalVelocity=0;
    private float distToGround;
    void Awake () {
        anim = GetComponent <Animator> ();
        rb=GetComponent<Rigidbody>();
        
 
        //controller=GetComponent<CharacterController>();
    }
    void Update () {
		forward = Input.GetKey (KeyCode.W);
        back = Input.GetKey (KeyCode.S);
        left = Input.GetKey (KeyCode.A);
        right = Input.GetKey (KeyCode.D);
		angle_to_rotete=0;
        float jT=Mathf.Abs(anim.GetFloat("JumpingTiming")-0.60f);
        Vector3 vector;
		
        if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpTag") && !anim.GetBool("inTheMiddleOfJumping"))
        {
           /* kat=transform.eulerAngles.y;
            kat*=2.0f*3.14f/360.0f;*/
            Debug.Log("down"+jT*jumpforce);
            vector=new Vector3(0,jT*jumpforce,0);
            transform.position -=vector;
             vector=new Vector3(0.1f*Mathf.Sin(kat),0,0.1f*Mathf.Cos(kat));
            transform.position +=vector;
            
            // transform.position=center_point.position;
            
        }
        if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpTag")&& anim.GetBool("inTheMiddleOfJumping"))
        {
           /* kat=transform.eulerAngles.y;
            kat*=2.0f*3.14f/360.0f;*/
            Debug.Log("up"+jT*jumpforce);
            vector=new Vector3(0,jT*jumpforce,0);
            transform.position +=vector;
            vector=new Vector3(0.1f*Mathf.Sin(kat),0,0.1f*Mathf.Cos(kat));
            transform.position +=vector;
        //     transform.position=center_point.position;
        //    Player_cam.LookAt (center_point);
            
        }
		
        anim.SetFloat ("movement",Mathf.Max( Mathf.Abs(Input.GetAxis ("Vertical")),  Mathf.Abs(Input.GetAxis ("Horizontal"))  ));
        if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("walkingWeap"))
        {
            transform.eulerAngles += new Vector3 (0, Mathf.DeltaAngle (transform.eulerAngles.y, center_point.eulerAngles.y+angle_to_rotete) * Time.deltaTime * rotation_speed, 0);
            anim.SetFloat ("y",Input.GetAxis ("Vertical"));
            anim.SetFloat ("x",Input.GetAxis ("Horizontal"));
        }
        else
        {
          //  Debug.Log(controller.isGrounded);
           // Debug.Log(verticalVelocity);
           // if (controller.isGrounded)
            {
                //verticalVelocity=-gravity*Time.deltaTime;
                if (Input.GetAxis ("Jump")>0.0f)
                {
                    
                    anim.SetBool ("jumping",true);
                    kat=transform.eulerAngles.y-10;
                    kat*=2.0f*3.14f/360.0f;
                    /*Debug.Log(transform.eulerAngles.y);
                    Debug.Log(Mathf.Sin(kat));
                    Debug.Log(Mathf.Cos(kat));
*/

                    /*vector=new Vector3(1.0f*Mathf.Sin(kat),0,1.0f*Mathf.Cos(kat));
                   transform.position +=vector;*/


                  //  verticalVelocity=jumpforce;
                    
                }
            }
          //  else
            {
          //      verticalVelocity=-gravity*Time.deltaTime;
            }
            // if (JUMPING==false)
            // {
            //     verticalVelocity=-gravity*Time.deltaTime;
               
            //     JUMPING=true;
            //     verticalVelocity=jumpforce;
              
               
            // }
            // else
            // {
            //         verticalVelocity=-gravity*Time.deltaTime;
            // }
//            Vector3 vector=new Vector3(0,verticalVelocity,0);
            //controller.Move(vector*Time.deltaTime);
           //  transform.position +=vector;

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
    
}
