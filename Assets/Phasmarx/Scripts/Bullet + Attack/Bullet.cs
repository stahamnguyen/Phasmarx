using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int power;
	HealthPlayer health;
	float timer;

	void Start () {

		health = GameObject.Find ("Player").GetComponent<HealthPlayer> ();

	}

	void Update(){
		if (timer < 3f) {
			timer += Time.deltaTime;
		} else if (timer >= 3f) {
			Destroy (gameObject);
		}
			
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.isTrigger != true) {

			if (target.gameObject.tag == "Player") {
				health.Damaged (power);
			}

			Destroy (gameObject);

		}
	}
}
