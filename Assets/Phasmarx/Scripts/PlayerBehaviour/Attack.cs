using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AbstractBehaviour {

	public bool attacking;
	float attackTimer = 0f;
	float attackCooldown = 0.2f;
	public AudioClip sound;

	public Collider2D attackTrigger1, attackTrigger2;
	public Transform attackPointLeft, attackPointRight;

	Equip equipBehaviour;

	// Use this for initialization

	void Start () {
		equipBehaviour = GetComponent<Equip> ();
	}

	protected virtual void OnAttack (bool value){

		attacking = value;

		if (value) {

			if (renderer2D.flipX) {
				Collider2D attackTriggerClone;
				attackTriggerClone = Instantiate ((equipBehaviour.currentItem == 0) ? attackTrigger1 : attackTrigger2, attackPointLeft.transform.position, attackPointLeft.transform.rotation) as Collider2D;
			} else if (!renderer2D.flipX) {
				Collider2D attackTriggerClone;
				attackTriggerClone = Instantiate ((equipBehaviour.currentItem == 0) ? attackTrigger1 : attackTrigger2, attackPointRight.transform.position, attackPointRight.transform.rotation) as Collider2D;
			}

			GetComponent<AudioSource> ().PlayOneShot (sound);
		}



		ToggleScripts (!attacking);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("c") && !attacking) {
			OnAttack(true);
			attackTimer = attackCooldown;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else if (!Input.GetKeyDown("c")) {
				OnAttack (false);
			}
		}

	}
}

