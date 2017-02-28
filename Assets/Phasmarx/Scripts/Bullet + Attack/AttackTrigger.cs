using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : AbstractBehaviour {

	public int attackPower;
	public CircleCollider2D circle2d;
	string targetTag = "Enemy";
	float timer;


	// Use this for initialization
	void Start () {
		
		circle2d = GetComponent<CircleCollider2D> ();
		ToggleScripts (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 0.2f) {
			timer += Time.deltaTime;
		} else if (timer >= 0.2f) {
			Destroy (gameObject);
		}
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {

			target.SendMessageUpwards ("RemoveHealth", attackPower);
			
		}
	}
}
