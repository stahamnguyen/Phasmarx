using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour {

	public static WindowsManager manager;
	public int canContinue;

	public GameObject firstSelected;

	protected EventSystem eventSystem{
		get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
	}

	public virtual void OnFocus(){
		eventSystem.SetSelectedGameObject (firstSelected);
	}

	protected virtual void Display(bool value){
		gameObject.SetActive (value);
	}

	public virtual void Open(){
		Display (true);
		OnFocus ();
	}

	public virtual void Close(){
		Display (false);
	}
		
	protected virtual void Awake () {
		Close ();
		canContinue = PlayerPrefs.GetInt("continue", 0);
	}

}
