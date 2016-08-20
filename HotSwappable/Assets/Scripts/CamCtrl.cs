﻿using UnityEngine;
using System.Collections;

public class CamCtrl : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Mouse X") * 2f;
		target.transform.RotateAround (target.transform.position, new Vector3 (0, 1, 0), x);
		float y = Input.GetAxis ("Mouse Y") * 2f;
		transform.RotateAround (target.transform.position, new Vector3 (0, 0, 0), y);
	}
}