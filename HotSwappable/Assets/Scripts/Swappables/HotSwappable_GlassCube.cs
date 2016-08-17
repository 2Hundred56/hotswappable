using UnityEngine;
using System.Collections;

public class HotSwappable_GlassCube : HotSwappable_Launchable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			GetComponent<Rigidbody>().velocity += new Vector3 (0, 4, 0);
			print ("Fly, little cube, fly!!");
		}
	}
}
