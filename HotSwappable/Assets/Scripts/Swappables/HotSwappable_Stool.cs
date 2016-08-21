using UnityEngine;
using System.Collections;

public class HotSwappable_Stool : HotSwappable_Launchable {

	// Use this for initialization
	void Start () {
	
	}

	public override void Control () {
		base.Control();
		if (Input.GetKey (KeyCode.W)) {
			transform.position += transform.forward / 10;
		}
	}

}
