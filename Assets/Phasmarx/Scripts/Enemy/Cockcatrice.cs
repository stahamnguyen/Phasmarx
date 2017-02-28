using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockcatrice : MonoBehaviour {

	public float distance;
	public float bulletTimer;
	public float bulletSpeed = 20f;
	public float shootInterval;
	string targetTag = "Player";
	HealthPlayer health;

	public GameObject bullet;
	public Transform target;
	public Transform shootPoint;

	void Start () {

		health = GameObject.Find ("Player").GetComponent<HealthPlayer> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			health.Damaged (40);
		}
	}

	public void Attack(){

		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {

			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			GameObject bulletClone;
			bulletClone = Instantiate (bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;

			bulletTimer = 0;
		}


		
	}
		
}
