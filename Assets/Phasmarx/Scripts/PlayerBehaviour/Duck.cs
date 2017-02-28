using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : AbstractBehaviour {

	public bool ducking;

	public CapsuleCollider2D capsuleCollider;

	protected override void Awake(){
		base.Awake ();

		capsuleCollider = GetComponent<CapsuleCollider2D> ();

	}

	protected virtual void OnDuck (bool value){

		ducking = value;

		ToggleScripts (!ducking);

		if (ducking) {
			capsuleCollider.size = new Vector2(0.18f, 0.18f);
			capsuleCollider.offset = new Vector2(0f, -0.06f);
		} else {
			capsuleCollider.size = new Vector2(0.18f, 0.34f);
			capsuleCollider.offset = new Vector2(0f, 0f);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		var canDuck = inputState.GetButtonValue (inputButtons [0]);
		if (canDuck && collisionState.standing && !ducking) {
			OnDuck (true);
		} else if (ducking && !canDuck) {
			OnDuck (false);
		}
		
	}
}
