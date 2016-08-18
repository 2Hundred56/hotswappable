using UnityEngine;
using System.Collections;

public class HotSwappable_SodaCan : HotSwappable {

	// Use this for initialization
	void Start () {
	
	}

	public override Vector3 getIdealCameraPos() {
		return new Vector3 (10000000, 54325, 3);	
	}
}
