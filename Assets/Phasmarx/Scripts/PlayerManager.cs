using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace path{


public class PlayerManager : MonoBehaviour {

	InputState inputState;
	Run runBehaviour;
	Jump jumpBehaviour;
	Animator animator;
	CollisionState collisionState;
	Duck duckBehaviour;
	Attack attackBehaviour;
	Knockback knockbackBehaviour;
	Equip equipBehaviour;
	HealthPlayer health;

	void Awake () {
		inputState = GetComponent<InputState> ();
		runBehaviour = GetComponent<Run> ();
		jumpBehaviour = GetComponent<Jump> ();
		animator = GetComponent<Animator> ();
		collisionState = GetComponent<CollisionState> ();
		duckBehaviour = GetComponent<Duck> ();
		attackBehaviour = GetComponent<Attack> ();
		knockbackBehaviour = GetComponent<Knockback> ();
		equipBehaviour = GetComponent<Equip> ();
		health = GetComponent<HealthPlayer> ();
	}

	// Use this for initialization
	void Start () {

		health.curHealth = PlayerPrefs.GetInt ("curHealth", health.maxHealth);
		equipBehaviour.currentItem = PlayerPrefs.GetInt ("_currentItem", 0);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (collisionState.standing) {
			ChangeAnimationState (0);
		}

		if (runBehaviour.run && !jumpBehaviour.jump) {
			ChangeAnimationState (1);
		}

		if (inputState.absVelY > 0.1f && !runBehaviour.run) {
			ChangeAnimationState (3);
		}

		if (inputState.absVelY > 0.1 && runBehaviour.run) {
			ChangeAnimationState (2);
		}

		if (duckBehaviour.ducking) {
			ChangeAnimationState (4);
		}

		if (attackBehaviour.attacking) {
			ChangeAnimationState (5);
		}

		if (knockbackBehaviour.onKnockback) {
			ChangeAnimationState (6);
		}
		
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("_currentItem", equipBehaviour.currentItem);
		PlayerPrefs.SetInt ("curHealth", health.curHealth);
	}
}
}

