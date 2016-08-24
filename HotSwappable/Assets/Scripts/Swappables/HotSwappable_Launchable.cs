using UnityEngine;
using System.Collections;

public class HotSwappable_Launchable : HotSwappable {

	float throw_cooldown = 100f;
	float throw_state=0;

	public void Update () {
		throw_cooldown = GetComponent<Rigidbody> ().mass * 10;
		if (throw_state > 0) {
			throw_state--;
		}
	}

	public override void Launch() {
		if (throw_state==0) {
			GetComponent<Rigidbody> ().velocity += transform.up * 5 + transform.forward * 5;
			throw_state = throw_cooldown;
		}

	}
}
