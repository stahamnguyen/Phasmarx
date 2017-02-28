using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health;

	public void RemoveHealth(int value){
		health -= value;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
