using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : AbstractBehaviour {

	public float speed = 7f;
	public bool run;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);

		if (right || left) {
			var runSpeed = speed;

			var velX = runSpeed * (float)inputState.direction;

			run = true;

			body2d.velocity = new Vector2 (velX, body2d.velocity.y);
		} else {
			run = false;
		}
	}
}
