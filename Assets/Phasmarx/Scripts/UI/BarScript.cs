using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	[SerializeField]
	float fillAmount;

	[SerializeField]
	Image content;

	HealthPlayer health;

	void Awake (){
	}

	void Start () {
		health = GameObject.Find ("Player").GetComponent<HealthPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {

		HandleBar ();
		
	}

	void HandleBar(){
		content.fillAmount = Map(health.curHealth, 0, health.maxHealth, 0, 1);
	}

	float Map(float value, float inMin, float inMax, float outMin, float outMax){

		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		
	}
}
