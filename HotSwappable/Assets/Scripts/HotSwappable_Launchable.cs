using UnityEngine;
using System.Collections;

public class HotSwappable_Launchable : HotSwappable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (base.Controlled) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<Rigidbody> ().velocity += transform.forward * 4;
			}
		}
	}
}
