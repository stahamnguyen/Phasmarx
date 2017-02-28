using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour {

	public float bulletTimer;
	public float bulletSpeed = 10f;
	public float shootInterval;
	public float timerChangeColor;
	public int collidingDamage = 5;
	public float direction = 0f;
	public float frequency = 1.0f;
	public Vector3 positionA;
	public Vector3 positionB;
	float elapsedTime = 0.0f;
	string targetTag = "Player";

	SpriteRenderer devilRenderer;
	HealthPlayer health;
	public GameObject bullet;
	public Transform target;
	public Transform shootPoint;


	// Use this for initialization
	void Start () {
		devilRenderer = GetComponent<SpriteRenderer> ();
		health = GameObject.Find ("Player").GetComponent<HealthPlayer> ();
	}

	// Update is called once per frame
	void Update () {

		if (timerChangeColor < 0.25f) {
			timerChangeColor += Time.deltaTime;
		} else if (timerChangeColor >= 0.25f) {
			devilRenderer.color = new Color(255f, 255f, 255f, 255f);
			timerChangeColor = 0;
		}

		elapsedTime += Time.deltaTime;
		float cosineValue = Mathf.Cos(2.0f * Mathf.PI * frequency * elapsedTime);
		transform.position = positionA + (positionB - positionA) * 0.5f * (1 - cosineValue);

		CheckDistance ();

	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			health.Damaged (collidingDamage);
		}

		if (target.gameObject.tag == "Attack") {
			devilRenderer.color = new Color(255f, 0f, 0f, 255f);


		}


		if (target.gameObject.tag == "Wall") {
			devilRenderer.flipX = !devilRenderer.flipX;
			direction *= -1;
		}

	}

	public void Attack(){

		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {

			Vector2 direction = target.position - transform.position;
			direction.Normalize ();

			GameObject bulletClone;
			bulletClone = Instantiate (bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;

			bulletTimer = 0;
		}
	}

	void CheckDistance(){

		float distance = Vector3.Distance (target.position, transform.position);

		if (distance <= 10) {

			Attack ();

		}

	}


}
