using UnityEngine;
using System.Collections;

public class HotSwappable : MonoBehaviour {
	public bool Controlled = false;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Controlled) {
			Control ();
		} 
	}

	public virtual void Control () {
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			transform.rotation = new Quaternion ();
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (new Vector3 (0, -1, 0));
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (new Vector3 (0, 1, 0));
		}

	}
	public virtual void StartControl() {
		Controlled = true;
		Debug.Log (name + " gained control");
	}
	public virtual void EndControl() {
		Controlled = false;
		Debug.Log (name + " lost control");
	}

}

