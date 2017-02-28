 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeCockcatrice : MonoBehaviour {

	public Cockcatrice cockcatriceAI;



	void Awake(){

		cockcatriceAI = GetComponentInParent<Cockcatrice> ();
		
	}

	void OnTriggerStay2D(Collider2D target){
	
		if (target.gameObject.tag == "Player") {
		
			cockcatriceAI.Attack ();

		}

	}
}
