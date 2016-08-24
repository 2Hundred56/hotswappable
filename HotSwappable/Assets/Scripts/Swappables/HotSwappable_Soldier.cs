using UnityEngine;
using System.Collections;

public class HotSwappable_Soldier : HotSwappable_Launchable { 
	void Start () {
		speed = 1f;
		Debug.Log (speed);
	}

	public override void StartControl() {
		base.StartControl ();
		GetComponent<Rigidbody> ().constraints |= RigidbodyConstraints.FreezeRotationX;
		GetComponent<Rigidbody> ().constraints |= RigidbodyConstraints.FreezeRotationZ;
	}
	public override void EndControl() {
		base.EndControl ();
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
	}
		
		
}
