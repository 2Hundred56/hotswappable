using UnityEngine;
using System.Collections;

public class Swappable_Controller : MonoBehaviour {
	public HotSwappable target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target.Controlled) {
			target.Control();
		}
	}
}
