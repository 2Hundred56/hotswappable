using UnityEngine;
using System.Collections;

public class HotSwappable : MonoBehaviour {
	protected bool Controlled = false;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Controlled) {
			Control (); 
		}
	}

	public virtual void Control () {
		
	}
}
