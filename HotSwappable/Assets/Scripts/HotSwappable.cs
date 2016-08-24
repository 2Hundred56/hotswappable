using UnityEngine;
using System.Collections;

public class HotSwappable : MonoBehaviour {
	public float speed = 0.2f;
	public Quaternion moveAxis = new Quaternion();
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	public virtual void StartControl() {
		Debug.Log (name + " gained control");
	}
	public virtual void EndControl() {
		Debug.Log (name + " lost control");
	}
	public virtual void Launch() {

	}
	public virtual void Rotate(float Angle) {
		transform.Rotate (new Vector3 (0, Angle, 0));

	}

}

