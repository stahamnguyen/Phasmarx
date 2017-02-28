using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordOfLight : Collectable {

	public int itemID = 1;

	override protected void OnCollect(GameObject target){

		var equipBehaviour = target.GetComponent<Equip> ();
		if (equipBehaviour != null) {
			equipBehaviour.currentItem = itemID;

		}
	
	}

	void Awake(){
		if (PlayerPrefs.GetInt("_currentItem") == 1){
			gameObject.SetActive(false);
		}
	}
}
