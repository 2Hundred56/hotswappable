using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour {
	public GameObject Target;
	public float ZoomValue = 1;
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
	public void ChangeTarget(GameObject NewTarget) {
		Target = NewTarget;
		GoalPos = new Vector3 (0, ZoomValue * 3, -ZoomValue * 3);
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
			GoalPos.x -= dx;
			GoalPos.z -= dy;
		}

	
	}

	void LateUpdate () {
		Vector3 TargetPos = Target.transform.position;
		GoalPos += (TargetPos - LastPos);

		transform.position += Lerp * (GoalPos - transform.position);
		LastMouseX = Input.GetAxis ("Mouse X");
		LastMouseY = Input.GetAxis ("Mouse Y");
		LastPos = TargetPos;
		LastRot = Target.transform.rotation;
	}
	public void Zoom(float NewZoom) {
		ZoomValue = NewZoom;
		GoalPos = (GoalPos - LastPos) * ZoomValue + LastPos;
	}
}
