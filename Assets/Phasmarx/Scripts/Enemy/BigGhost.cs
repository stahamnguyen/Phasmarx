using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGhost : MonoBehaviour {

	public float timerChangeColor;
	public int collidingDamage = 40;

	SpriteRenderer bigGhostRenderer;
	HealthPlayer health;
	Spawner spawner;

	float amplitudeX = 3.0f;
	float amplitudeY = 5.0f;
	float omegaX = 1.0f;
	float omegaY = 5.0f;
	float index;

	string targetTag = "Player";

	void Awake(){
		if (PlayerPrefs.GetInt ("killedBigGhost") == 1) {
			gameObject.SetActive (false);
		}
	}

	void Start () {
		bigGhostRenderer = GetComponent<SpriteRenderer> ();
		health = GameObject.Find ("Player").GetComponent<HealthPlayer> ();
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
	}

	public void Update(){
		index += Time.deltaTime;
		float x = amplitudeX * Mathf.Cos (omegaX * index);
		float y = Mathf.Abs (amplitudeY * Mathf.Sin (omegaY * index));
		transform.localPosition= new Vector3(2 * x + 8, y,0);

		if (timerChangeColor < 0.25f) {
			timerChangeColor += Time.deltaTime;
		} else if (timerChangeColor >= 0.25f) {
			bigGhostRenderer.color = new Color(255f, 255f, 255f, 255f);
			timerChangeColor = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			health.Damaged (collidingDamage);
		}

		if (target.gameObject.tag == "Attack") {
			bigGhostRenderer.color = new Color(255f, 0f, 0f, 255f);
		}

	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("killedBigGhost", 1);
		spawner.active = false;
	}
}
