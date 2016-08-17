using UnityEngine;
using System.Collections;

public class HotSwappable_Launchable : HotSwappable {

	float throw_cooldown = 100f;
	float throw_state=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void Control ()
	{
		base.Control ();
		if (Input.GetKeyDown (KeyCode.Space) && throw_state==0) {
			GetComponent<Rigidbody> ().velocity += transform.forward * 5 + transform.up*5;
			throw_state = throw_cooldown;
		}
		if (throw_state > 0) {
			throw_state--;
		}
	}
}
