using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehaviour {

	public float jumpSpeed = 15f;
	public float jumpDelay = .0000001f;
	public int jumpCount = 2;
	public bool jump;

	protected float lastJumpTime = 0;
	protected int jumpsRemaining = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var canJump = inputState.GetButtonValue (inputButtons [0]);
		var holdTime = inputState.GetButtonHoldTime (inputButtons [0]);

		if (collisionState.standing) {
			if (canJump && holdTime < .0000001f) {
				jumpsRemaining = jumpCount - 1;
				OnJump ();
				jump = true;
			}
		} else if (canJump && holdTime < .0000001f && Time.time - lastJumpTime > jumpDelay && PlayerPrefs.GetInt("killedBigGhost") == 1) {
			if (jumpsRemaining > 0) {
				OnJump ();
				jumpsRemaining--;
			}
		} else
			jump = false;
	}

	protected virtual void OnJump(){
		var vel = body2d.velocity;
		lastJumpTime = Time.time;
		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}
}
