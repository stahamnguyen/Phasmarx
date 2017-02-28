using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : AbstractBehaviour {

	string targetTag = "Enemy";
	public bool onKnockback;
	public AudioClip sound;
	Knockback knockBack;
	SpriteRenderer renderer2d;

	void Start(){

		knockBack = GetComponent<Knockback> ();
		renderer2d = GetComponent<SpriteRenderer> ();

	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == targetTag) {
			StartCoroutine (knockBack.KnockBack (0.001f, 1f));

		}
	}

//	void OnTriggerStay2D(Collider2D target){
//		if (target.gameObject.tag == targetTag) {
//			StartCoroutine (knockBack.KnockBack (0.001f, 1.2f));
//
//		}
//	}

	public IEnumerator KnockBack (float knockDur, float amplifier){
		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime;

			if (!renderer2d.flipX) {
				body2d.velocity = new Vector2 (-10 * amplifier, 20 * amplifier);
			} else {
				body2d.velocity = new Vector2 (10 * amplifier, 20 * amplifier);
			}
				
			GetComponent<AudioSource> ().PlayOneShot (sound);

			onKnockback = true;
			ToggleScripts (!onKnockback);
			Physics2D.IgnoreLayerCollision (10, 9);
		}

		yield return new WaitForSeconds (0.6f);

		onKnockback = false;
		ToggleScripts (!onKnockback);

		yield return new WaitForSeconds (0.9f);

		Physics2D.IgnoreLayerCollision (10, 9, false);

	}
}
