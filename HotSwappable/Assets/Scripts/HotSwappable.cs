﻿using UnityEngine;
using System.Collections;

public class HotSwappable : MonoBehaviour {
	public float speed = 0.1f;
	public Quaternion moveAxis = new Quaternion();
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	public virtual void StartControl() {
		Debug.Log (name + " gained control");
	}
	public virtual void EndControl() {
		Debug.Log (name + " lost control");
	}
	public virtual void Launch() {

	}

}

