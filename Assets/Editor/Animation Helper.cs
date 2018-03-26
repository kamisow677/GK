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
	 public AnimationClip equipWeapAnim; 
	 public AnimationClip idleWeapAnim; 
	 public AnimationClip hideWeapAnim; 

	 public AnimationClip walkForwardWeapAnim; 
	 public AnimationClip walkBackwardWeapAnim; 
	 public AnimationClip walkRightWeapAnim; 
	 public AnimationClip walkLeftWeapAnim; 

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
		equipWeapAnim = EditorGUILayout.ObjectField("Equip weapon", equipWeapAnim, typeof(AnimationClip), false) as AnimationClip; 
		idleWeapAnim = EditorGUILayout.ObjectField("idle weapon", idleWeapAnim, typeof(AnimationClip), false) as AnimationClip; 
		hideWeapAnim = EditorGUILayout.ObjectField("Hide weapon", hideWeapAnim, typeof(AnimationClip), false) as AnimationClip; 

		walkForwardWeapAnim = EditorGUILayout.ObjectField("walkForwardWeapAnim", walkForwardWeapAnim, typeof(AnimationClip), false) as AnimationClip; 
		walkBackwardWeapAnim = EditorGUILayout.ObjectField("walkBackwardWeapAnim", walkBackwardWeapAnim, typeof(AnimationClip), false) as AnimationClip; 
		walkRightWeapAnim = EditorGUILayout.ObjectField("walkRightWeapAnim", walkRightWeapAnim, typeof(AnimationClip), false) as AnimationClip; 
		walkLeftWeapAnim = EditorGUILayout.ObjectField("walkLeftWeapAnim", walkLeftWeapAnim, typeof(AnimationClip), false) as AnimationClip; 
		
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
		AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath("Assets/" + target.name + ".controller");
		// Adds a float parameter called movement
		controller.AddParameter("movement", AnimatorControllerParameterType.Float);
		controller.AddParameter("jumping", AnimatorControllerParameterType.Bool);
		controller.AddParameter("endjumping", AnimatorControllerParameterType.Bool);
		controller.AddParameter("equipingWeapon", AnimatorControllerParameterType.Bool);
		controller.AddParameter("endEquipingWeapon", AnimatorControllerParameterType.Bool);
		controller.AddParameter("hidingWeapon", AnimatorControllerParameterType.Bool);
		controller.AddParameter("endHidingWeapon", AnimatorControllerParameterType.Bool);
		controller.AddParameter("x", AnimatorControllerParameterType.Float);
		controller.AddParameter("y", AnimatorControllerParameterType.Float);
		
		//Add states
		AnimatorState idleState = controller.layers[0].stateMachine.AddState("Idle");
		idleState.motion = idleAnim; 
		idleState.tag="idle";
		AnimatorState jumpInRunState = controller.layers[0].stateMachine.AddState("Jump In Run");
		jumpInRunState.motion = jumpInRunAnim; 

		AnimatorState idleWeapState = controller.layers[0].stateMachine.AddState("Idle Weapon");
		idleWeapState.motion = idleWeapAnim; 
		idleWeapState.tag="idleWeap";
		AnimatorState equipWeapState = controller.layers[0].stateMachine.AddState("Equiping Weapon");
		equipWeapState.motion = equipWeapAnim; 
		AnimatorState hideWeapState = controller.layers[0].stateMachine.AddState("Hiding Weapon");
		hideWeapState.motion = hideWeapAnim; 


		//Blend tree creation WALK-RUN
		BlendTree blendTree; 
		AnimatorState moveState = controller.CreateBlendTreeInController("Move", out blendTree); 
		moveState.tag="walking";
		//BlendTree setup 
		blendTree.blendType = BlendTreeType.Simple1D; 
		blendTree.blendParameter = "movement"; 
		blendTree.AddChild(walkAnim);
		blendTree.AddChild(runAnim); 

		

		//Transitions
		//Transition idleState-moveState-idleState
		AnimatorStateTransition LeaveIdle = idleState.AddTransition(moveState); 
		AnimatorStateTransition leaveMove = moveState.AddTransition(idleState); 
		LeaveIdle.AddCondition(AnimatorConditionMode.Greater, 0.01f, "movement"); 
		leaveMove.AddCondition(AnimatorConditionMode.Less, 0.01f, "movement"); 

		//Transitions
		//Transition moveState-jumpInRunState-moveState
		AnimatorStateTransition LeaveMove = moveState.AddTransition(jumpInRunState); 
		AnimatorStateTransition leaveJump = jumpInRunState.AddTransition(moveState); 
		LeaveMove.AddCondition(AnimatorConditionMode.If,1,"jumping"); 
		leaveJump.AddCondition(AnimatorConditionMode.If,1,"endjumping"); 


		//Transitions
		//Transition idleState-equipWeapState-idleWeapState
		AnimatorStateTransition LeaveIdleToEquiping = idleState.AddTransition(equipWeapState); 
		AnimatorStateTransition leaveEquipingWeap = equipWeapState.AddTransition(idleWeapState); 
		LeaveIdleToEquiping.AddCondition(AnimatorConditionMode.If,1,"equipingWeapon"); 
		leaveEquipingWeap.AddCondition(AnimatorConditionMode.If,1,"endEquipingWeapon"); 

		//Transitions
		//Transition idleWeapState-hideWeapState-idleState
		AnimatorStateTransition LeaveIdleToHiding = idleWeapState.AddTransition(hideWeapState); 
		AnimatorStateTransition leaveHidingWeap = hideWeapState.AddTransition(idleState); 
		LeaveIdleToHiding.AddCondition(AnimatorConditionMode.If,1,"hidingWeapon"); 
		leaveHidingWeap.AddCondition(AnimatorConditionMode.If,1,"endHidingWeapon"); 

		//Blend tree creation WALK-RUN
		BlendTree blendTreeWeapon; 
		AnimatorState moveWeaponState = controller.CreateBlendTreeInController("Move with Weapon", out blendTreeWeapon); 
		moveWeaponState.tag="walkingWeap";
		//BlendTree setup 
		blendTreeWeapon.blendType = BlendTreeType.SimpleDirectional2D; 
		blendTreeWeapon.blendParameter = "x"; 
		blendTreeWeapon.blendParameterY = "y"; 
		blendTreeWeapon.AddChild(walkForwardWeapAnim, new Vector2(0,1));
		blendTreeWeapon.AddChild(walkBackwardWeapAnim, new Vector2(0,-1)); 
		blendTreeWeapon.AddChild(walkRightWeapAnim, new Vector2(1,0));
		blendTreeWeapon.AddChild(walkLeftWeapAnim, new Vector2(-1,0)); 

		//Transitions
		//Transition idleWeapState-moveWeaponState-idleWeapState
		AnimatorStateTransition LeaveIdleWeapState= idleWeapState.AddTransition(moveWeaponState); 
		AnimatorStateTransition leaveMoveWeaponState = moveWeaponState.AddTransition(idleWeapState); 
		LeaveIdleWeapState.AddCondition(AnimatorConditionMode.Greater, 0.01f, "movement"); 
		leaveMoveWeaponState.AddCondition(AnimatorConditionMode.Less, 0.01f, "movement"); 

		target.GetComponent<Animator>().runtimeAnimatorController = controller;
	}
} 
#endif