#if UNITY_EDITOR 
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
public class AnimationHelper : EditorWindow 
{
	 public GameObject target; 
	 public AnimationClip idleAnim; 
	 public AnimationClip walkAnim; 
	 public AnimationClip runAnim; 
	 public AnimationClip jumpInRunAnim; 
	 [MenuItem ("Window/Animator Helper")] 
	 static void OpenWindow () 
	 { //Get existing open window or if none, make a new one: 
		 GetWindow<AnimationHelper>(); 
	 } 
	 void OnGUI()
	{ 
		target = EditorGUILayout.ObjectField("Target Object", target, typeof(GameObject), true) as GameObject; 
		idleAnim = EditorGUILayout.ObjectField("Idle", idleAnim, typeof(AnimationClip), false) as AnimationClip; 
		walkAnim = EditorGUILayout.ObjectField("Walk", walkAnim, typeof(AnimationClip), false) as AnimationClip; 
		runAnim = EditorGUILayout.ObjectField("Run", runAnim, typeof(AnimationClip), false) as AnimationClip; 
		jumpInRunAnim = EditorGUILayout.ObjectField("Jump In Run", jumpInRunAnim, typeof(AnimationClip), false) as AnimationClip; 
		
		if (GUILayout.Button("Create")) 
		{ 
			if (target == null)
			{ 
				Debug.LogError ("No target for animator controller set.");
				return; 
			} 
			Create(); 
		} 
	} 
	void Create () 
	{ 
		AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath("Assets/Player Animations/" + target.name + ".controller");
		// Adds a float parameter called movement
		controller.AddParameter("movement", AnimatorControllerParameterType.Float);
		controller.AddParameter("jumping", AnimatorControllerParameterType.Bool);
		controller.AddParameter("endjumping", AnimatorControllerParameterType.Bool);
		//Add states
		AnimatorState idleState = controller.layers[0].stateMachine.AddState("Idle");
		idleState.motion = idleAnim; 
		AnimatorState jumpInRunState = controller.layers[0].stateMachine.AddState("Jump In Run");
		jumpInRunState.motion = jumpInRunAnim; 


		//Blend tree creation 
		BlendTree blendTree; 
		AnimatorState moveState = controller.CreateBlendTreeInController("Move", out blendTree); 
		moveState.tag="walking";
		//BlendTree setup 
		blendTree.blendType = BlendTreeType.Simple1D; 
		blendTree.blendParameter = "movement"; 
		blendTree.AddChild(walkAnim);
		blendTree.AddChild(runAnim); 

		

		//Transitions
		//Transition move-idle
		AnimatorStateTransition LeaveIdle = idleState.AddTransition(moveState); 
		AnimatorStateTransition leaveMove = moveState.AddTransition(idleState); 
		LeaveIdle.AddCondition(AnimatorConditionMode.Greater, 0.01f, "movement"); 
		leaveMove.AddCondition(AnimatorConditionMode.Less, 0.01f, "movement"); 

		//Transitions
		//Transition move-idle
		AnimatorStateTransition LeaveMove = moveState.AddTransition(jumpInRunState); 
		AnimatorStateTransition leaveJump = jumpInRunState.AddTransition(moveState); 
		LeaveMove.AddCondition(AnimatorConditionMode.If,1,"jumping"); 
		leaveJump.AddCondition(AnimatorConditionMode.If,1,"endjumping"); 

		target.GetComponent<Animator>().runtimeAnimatorController = controller;
	}
} 
#endif