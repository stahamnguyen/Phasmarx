using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pass : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.CompareTag("Player")) {
			SceneManager.LoadScene ("GameStaging1");
			PlayerPrefs.SetInt ("stage", 1);
		}
	}
}
