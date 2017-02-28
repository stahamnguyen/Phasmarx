using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartWindow : GenericWindow {

	public Button continueButton;
	public string levelToLoad;
	public string levelToLoad1;
	int stage;

	public override void Open ()
	{
		continueButton.gameObject.SetActive (canContinue == 1);

		if (continueButton.gameObject.activeSelf) {
			firstSelected = continueButton.gameObject;
		}

		base.Open ();
	}

	public void GameStart(){
		SceneManager.LoadScene (levelToLoad);
		PlayerPrefs.SetInt("continue", 1);
		PlayerPrefs.DeleteKey("curHealth");
		PlayerPrefs.DeleteKey("_currentItem");
		PlayerPrefs.DeleteKey ("killedBigGhost");
	}

	public void Continue(){

		stage = PlayerPrefs.GetInt ("stage", 0);

		if (stage == 0) {
			SceneManager.LoadScene (levelToLoad);
		} else {
			SceneManager.LoadScene (levelToLoad1);
		}
		
	}

	public void BossRush(){
	}



}
