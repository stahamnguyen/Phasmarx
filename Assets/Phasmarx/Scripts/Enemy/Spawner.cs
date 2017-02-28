using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject prefab;
	public float delay = 3.0f;
	public bool active = true;

	void Awake(){
		if (PlayerPrefs.GetInt ("killedBigGhost") == 1) {
			active = false;
		}
	}

	void Start () {

		StartCoroutine (Generator ());
		
	}

	IEnumerator Generator(){
		yield return new WaitForSeconds (delay);

		if (active) {
			var newTransform = transform;

			Instantiate (prefab, newTransform.position, Quaternion.identity);
		}

		StartCoroutine (Generator ());
	}

}
