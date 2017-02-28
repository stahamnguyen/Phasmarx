using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float scale = 1f;
	public float pixelToUnits = 1f;
	public bool bounds;
	Vector2 nativeResolution = new Vector2 (32*2/3, 20*2/3);

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	Transform t;

	void Awake(){
		var cam = GetComponent<Camera> ();

		if (cam.orthographic) {
			scale = Screen.height / nativeResolution.y;
			pixelToUnits *= scale;
			cam.orthographicSize = (Screen.height / 2f) / pixelToUnits;
		}

	}

	// Use this for initialization
	void Start () {
		t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = new Vector3 (t.position.x, transform.position.y, transform.position.z);
		}

		if (bounds) {
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x), Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y), transform.position.z);
		}
	}
}
