using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int speed = 0;
	private AudioManager audioManager;
	private float zPos;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// get input data from keyboard or controller
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		//bool triggerDown = Input.GetButtonDown("Fire1");
		//bool triggerUp = Input.GetButtonUp("Fire1");
		bool triggerDown = Input.GetKeyDown("space");
		bool triggerUp = Input.GetKeyUp("space");

		// update player position based on input
		Vector3 position = transform.position;
		position.x += moveHorizontal * speed * Time.deltaTime;
		position.z += moveVertical * speed * Time.deltaTime;
		transform.position = position;

		if (triggerDown) {
			FindObjectOfType<AudioManager>().PlayLoop();
		}

		if (triggerUp) {
			FindObjectOfType<AudioManager>().EndLoop();
		}

		FindObjectOfType<AudioManager>().ChangePitch(position.z);
	}
}
