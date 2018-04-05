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
    private float jumpforce=25.0f;
    private float jumpdist=3.0f;
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
         RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.5f))
        {
           // Debug.Log("FFALSE " + hit.distance);
            anim.SetBool ("inAir",false);
        }
        else
        {
           // Debug.Log("TRUE " + hit.distance);
            anim.SetBool ("inAir",true);
        }
        //bool pla=Physics.Raycast(transform.position, -Vector3.up, distToGround, 0.1);
		
        int time=(int) (anim.GetFloat("JumpingTiming")*100);
        if ((anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpTag") || anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpStaticTag"))
            && !anim.GetBool("inTheMiddleOfJumping") )
        {
            //move down
            vector=new Vector3(0,jT*jumpforce*Time.deltaTime,0);
            transform.position -=vector;
            //move forward
             vector=new Vector3(jumpdist*Mathf.Sin(kat)*Time.deltaTime,0,(jumpdist)*Mathf.Cos(kat)*Time.deltaTime);
            transform.position +=vector;
            //move forward
            if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpStaticTag"))
            {
                Debug.Log("wszedlem");
                vector=new Vector3(0,20*Time.deltaTime,0);
                transform.eulerAngles +=vector;
            }
            
            
        }
        if ((anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpTag") || anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpStaticTag"))
           && anim.GetBool("inTheMiddleOfJumping") )
        {
            //move up
            vector=new Vector3(0,jT*jumpforce*Time.deltaTime,0);
            transform.position +=vector;
            //move forward
            vector=new Vector3(jumpdist*Mathf.Sin(kat)*Time.deltaTime,0,(jumpdist)*Mathf.Cos(kat)*Time.deltaTime);
            transform.position +=vector;
            //move forward
            if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpStaticTag"))
            {
                Debug.Log("wszedlem");
                vector=new Vector3(0,20*Time.deltaTime,0);
                transform.eulerAngles +=vector;
            }
            
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
            {
                if (Input.GetAxis ("Jump")>0.0f && !isInAir())
                {
                    
                    anim.SetBool ("jumping",true);
                    if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("jumpTag"))
                        kat=transform.eulerAngles.y-10;
                    else
                        kat=transform.eulerAngles.y;
                    kat*=2.0f*3.14f/360.0f;
                }
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
    private bool isInAir()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, -Vector3.up, out hit, 0.3f)? false:true;
        
    }
    
}
