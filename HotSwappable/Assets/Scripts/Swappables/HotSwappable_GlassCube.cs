using UnityEngine;
using System.Collections;

public class HotSwappable_GlassCube : HotSwappable_Launchable {

	// Use this for initialization
	void Start () {
	
	}

	public override void Control () {
		base.Control ();
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			GetComponent<Rigidbody> ().velocity += new Vector3 (0, 4, 0);
			print ("Fly, little cube, fly!!");
		}
	}
}
