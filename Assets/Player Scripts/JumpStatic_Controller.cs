using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStatic_Controller : StateMachineBehaviour {
	
	public Transform Player_cam;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		animator.SetBool ("inTheMiddleOfJumping", true);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		//Debug.Log(stateInfo.normalizedTime/34);
		//Debug.Log(stateInfo.normalizedTime);
		if (stateInfo.normalizedTime/34>0.60)
			animator.SetBool ("inTheMiddleOfJumping", false);
		if (stateInfo.normalizedTime/34>0.90)
		{
			animator.SetBool ("endjumping", true);
			animator.SetBool ("jumping", false);
			animator.SetBool ("inTheMiddleOfJumping", false);
			
		}
		animator.SetFloat("JumpingTiming",stateInfo.normalizedTime/34);
		
	}

	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool ("endjumping",false);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
