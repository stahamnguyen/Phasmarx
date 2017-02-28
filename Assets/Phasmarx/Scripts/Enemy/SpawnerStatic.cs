using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerStatic : MonoBehaviour {

	public GameObject prefab;
	public float delay = 3.0f;
	public bool active = true;

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
