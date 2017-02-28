using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeDevil : MonoBehaviour {

	public Devil devilAI;
	public Transform target;

	void Awake(){

		devilAI = GetComponentInParent<Devil> ();

	}

	void CheckDistance(){

			float distance = Vector3.Distance (target.position, transform.position);

			Debug.Log ("In range" + distance);

			if (distance <= 100) {


					devilAI.Attack ();


				Debug.Log ("In range");
			}

	}
}
