using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour {
	public GameObject Target;
	public float ZoomValue = 0.9f;
	public float Lerp = 0.1f;
	public Vector3 Pan = new Vector3(0,0,0);
	public float LastMouseX = 0;
	public float LastMouseY = 0;
	public Quaternion LastRot = new Quaternion();
	public Vector3 LastPos = new Vector3();
	public Vector3 GoalPos = new Vector3();
	public Quaternion GoalRot = new Quaternion();
	public Quaternion StartRot;
	public bool setup = true;
	// Use this for initialization
	void Start () {
		LastMouseX = Input.GetAxis ("Mouse X");
		LastMouseY = Input.GetAxis ("Mouse Y");
		StartRot = transform.rotation;
	}
	public void ChangeTarget(GameObject NewTarget) {
		Target = NewTarget;
		LastPos = Target.transform.position;
		LastRot = Target.transform.rotation;
		if (setup) {
			StartRot = transform.rotation;
			setup = false;
		}
		GoalPos = LastPos + new Vector3(0, ZoomValue * 3, -ZoomValue * 3);
		GoalRot = Quaternion.Euler (StartRot.eulerAngles.x,
			StartRot.eulerAngles.y+LastRot.eulerAngles.y,
			StartRot.eulerAngles.z);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			float x, y, dx, dy;
			x = Input.GetAxis ("Mouse X");
			y = Input.GetAxis ("Mouse Y");
			dx = x - LastMouseX;
			dy = y - LastMouseY;
			GoalPos.x -= dx;
			GoalPos.z -= dy;
			Pan.x -= dx;
			Pan.z -= dy;
		}
	
	}

	void LateUpdate () {
		if (Input.GetKey(KeyCode.LeftShift)) {
			return;
		}
		Vector3 TargetPos = Target.transform.position;
		Quaternion TargetRot = Target.transform.rotation;
		GoalPos += (TargetPos - LastPos);
		float YChange = TargetRot.eulerAngles.y - LastRot.eulerAngles.y;
		GoalPos = RotatePointAroundPivot (GoalPos-Pan, TargetPos, new Vector3 (0, YChange, 0))+Pan;
		GoalRot = Quaternion.Euler(new Vector3(GoalRot.eulerAngles.x,
			GoalRot.eulerAngles.y+YChange,
			GoalRot.eulerAngles.z));
		transform.rotation=Quaternion.Lerp(transform.rotation, GoalRot, Lerp);
				
		transform.position += Lerp * (GoalPos - transform.position);
		LastMouseX = Input.GetAxis ("Mouse X");
		LastMouseY = Input.GetAxis ("Mouse Y");
		LastPos = TargetPos;
		LastRot = TargetRot;
	}
	public void Zoom(float NewZoom) {
		ZoomValue = NewZoom;
		GoalPos = (GoalPos - Pan - LastPos) * ZoomValue + LastPos + Pan;
	}
	Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
		Vector3 dir = point - pivot;
		dir = Quaternion.Euler(angles) * dir;
		point = dir + pivot;
		return point;
	}

}
