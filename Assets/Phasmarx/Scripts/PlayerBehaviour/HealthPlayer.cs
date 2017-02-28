using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : AbstractBehaviour {

	public int maxHealth = 100;
	public int curHealth;
	public bool knockback;
	public string levelToLoad;
	public AudioClip sound;

	float timer;
	float timer1;

	StartWindow manager;


	// Use this for initialization
	void Start () {

//		curHealth = maxHealth;
		
	}

	// Update is called once per frame
	void Update () {

		if (curHealth > maxHealth)
			curHealth = maxHealth;

		if (curHealth <= 0) {
			if (timer < 0.2f) {
				timer += Time.deltaTime;
			} else if (timer >= 0.2f) {
				GetComponent<AudioSource> ().PlayOneShot (sound);
				if (timer1 < 0.01f) {
					timer1 += Time.deltaTime;
				} else if (timer >= 0.01f) {
					SceneManager.LoadScene (levelToLoad);
				}

				timer = 0;
			}
		}
		
	}


	public void Damaged(int damage){

		curHealth -= damage;
	}
}
