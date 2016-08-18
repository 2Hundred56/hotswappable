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
		
	}
	public virtual Vector3 getIdealCameraPos() {
		return new Vector3 (0, 9.8f, -(GetComponent<Collider> ().bounds.size.magnitude + 8.63f)) / 2f;
	}
	public virtual Quaternion getIdealCameraRot() {
		return Quaternion.Euler (new Vector3 (35.2904f, 0, 0));
	}
}

