using UnityEngine;
using System.Collections;

public class HotSwappable_Launchable : HotSwappable {

	float throw_cooldown = 100f;
	float throw_state=0;
	float throw_strength=0;

	public void Update () {
		throw_strength = 50 / GetComponent<Rigidbody> ().mass;
		if (throw_strength > 7) {
			throw_strength = 7;
		}
		if (throw_state > 0) {
			throw_state--;
		}
	}

	public override void Launch() {
		if (throw_state==0) {
			GetComponent<Rigidbody> ().velocity += transform.up * throw_strength + transform.forward * throw_strength;
			throw_state = throw_cooldown;
		}

	}
}
