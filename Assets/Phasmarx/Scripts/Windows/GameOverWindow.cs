using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWindow : GenericWindow {

	public string levelToLoad;

	public void OnBackToStartMenu(){
		SceneManager.LoadScene (levelToLoad);
		PlayerPrefs.DeleteKey("curHealth");
		Physics2D.IgnoreLayerCollision (10, 9, false);
	}

}
