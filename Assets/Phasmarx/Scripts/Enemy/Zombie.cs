using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	public float timerWaiting;
	public float timerChangeColor;
	public int collidingDamage = 1;
	public float direction = 0f;

	public Rigidbody2D zombieBody;
	public SpriteRenderer zombieRenderer;
	public Animator animator;
	HealthPlayer health;


	// Use this for initialization
	void Start () {
		zombieBody = GetComponent<Rigidbody2D> ();
		zombieRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		health = GameObject.Find ("Player").GetComponent<HealthPlayer> ();
	}

	// Update is called once per frame
	void Update () {

		if (timerWaiting < 1f) {
			timerWaiting += Time.deltaTime;
		} else if (timerWaiting >= 1f) {
			ChangeAnimationState (1);
			transform.Translate (2.5f * direction * Time.deltaTime, 0, 0);
		}

		if (timerChangeColor < 0.25f) {
			timerChangeColor += Time.deltaTime;
		} else if (timerChangeColor >= 0.25f) {
			zombieRenderer.color = new Color(255f, 255f, 255f, 255f);
			timerChangeColor = 0;
		}
		
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("Anim", value);
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			health.Damaged (collidingDamage);
		}

		if (target.gameObject.tag == "Attack") {
			zombieRenderer.color = new Color(255f, 0f, 0f, 255f);


		}


		if (target.gameObject.tag == "Wall") {
			zombieRenderer.flipX = !zombieRenderer.flipX;
			direction *= -1;
		}

	}


}
