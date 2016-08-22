using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour {
	public GameObject target;
	public float zoom = 1;
	public float lerp = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftShift)) {
			return;
		}
		/*float x = Input.GetAxis ("Mouse X") * 2f;
		target.transform.RotateAround (target.transform.position, new Vector3 (0, 1, 0), x);
		float y = Input.GetAxis ("Mouse Y") * 2f;
		transform.RotateAround (target.transform.position, new Vector3 (0, 0, 0), y);*/
	
	}

	void LateUpdate () {
		Vector3 goal = target.transform.position - new Vector3 (0, 0, zoom * 3) + new Vector3 (0, zoom * 3, 0);
		transform.position += lerp * (goal - transform.position);
	}
}
