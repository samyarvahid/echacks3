using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
/*
float xRotation = transform.rotation.eulerAngles.x;
		float yRotation =transform.eulerAngles.y;
		float zRotation = transform.rotation.eulerAngles.z;
		*/
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	Vector3 Update () {
	float xRotation = transform.rotation.eulerAngles.x;
		float yRotation =transform.rotation.eulerAngles.y;
		float zRotation = transform.rotation.eulerAngles.z;
		 transform.eulerAngles = new Vector3( xRotation, yRotation, zRotation );
		 
		 return transform.eulerAngles;
	}
}
