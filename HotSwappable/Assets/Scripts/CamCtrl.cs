using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour {
	public GameObject target;
	public float zoom = 1;
	public float lerp = 0.1f;
	public float xPan = 0;
	public float yPan = 0;
	public float zPan = 0;
	public float lastMouseX = 0;
	public float lastMouseY = 0;
	// Use this for initialization
	void Start () {
		lastMouseX = Input.GetAxis ("Mouse X");
		lastMouseY = Input.GetAxis ("Mouse Y");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			xPan -= 0.1f;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			xPan += 0.1f;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			zPan += 0.1f;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			zPan -= 0.1f;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			return;
		}
		if (Input.GetMouseButton (1)) {
			float x, y, dx, dy;
			x = Input.GetAxis ("Mouse X");
			y = Input.GetAxis ("Mouse Y");
			dx = x - lastMouseX;
			dy = y - lastMouseY;
			xPan -= dx;
			zPan -= dy;
		}

	
	}

	void LateUpdate () {
		Vector3 goal = target.transform.position + new Vector3 (0+xPan, zoom * 3 + yPan, -zoom * 3 + zPan);
		transform.position += lerp * (goal - transform.position);
		lastMouseX = Input.GetAxis ("Mouse X");
		lastMouseY = Input.GetAxis ("Mouse Y");
	}
}
