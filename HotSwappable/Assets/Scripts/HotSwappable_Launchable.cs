using UnityEngine;
using System.Collections;

public class HotSwappable_Launchable : HotSwappable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void Control ()
	{
		base.Control ();
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody> ().velocity += transform.up * 12;
		}
	}
}
