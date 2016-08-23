using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour {
	public GameObject target;
	public float Zoom = 1;
	public float Lerp = 0.1f;
	public float XPan = 0;
	public float YPan = 0;
	public float ZPan = 0;
	public float LastMouseX = 0;
	public float LastMouseY = 0;
	public Quaternion LastRot = new Quaternion();
	public Vector3 LastPos = new Vector3();
	public Vector3 GoalPos = new Vector3();
	// Use this for initialization
	void Start () {
		LastMouseX = Input.GetAxis ("Mouse X");
		LastMouseY = Input.GetAxis ("Mouse Y");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			XPan -= 0.1f;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			XPan += 0.1f;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			ZPan += 0.1f;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			ZPan -= 0.1f;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			return;
		}
		if (Input.GetMouseButton (1)) {
			float x, y, dx, dy;
			x = Input.GetAxis ("Mouse X");
			y = Input.GetAxis ("Mouse Y");
			dx = x - LastMouseX;
			dy = y - LastMouseY;
			XPan -= dx;
			ZPan -= dy;
		}

	
	}

	void LateUpdate () {
		Vector3 TargetPos = target.transform.position;
		Quaternion TargetRot = target.transform.rotation;
		GoalPos += (target.transform.position - LastPos);
		float YChange = target.transform.rotation.eulerAngles.y - LastRot.eulerAngles.y;
		transform.position += Lerp * (GoalPos - transform.position);
		LastMouseX = Input.GetAxis ("Mouse X");
		LastMouseY = Input.GetAxis ("Mouse Y");
		LastPos = TargetPos;
		LastRot = TargetRot;
	}
}
