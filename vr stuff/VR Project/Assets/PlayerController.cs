using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// Update is called once per frame
	void Update () {

		// get input data from keyboard or controller
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		bool triggerDown = Input.GetButtonDown("Fire1");
		bool triggerUp = Input.GetButtonUp("Fire1");
		//bool triggerDown = Input.GetKeyDown("space");
		//bool triggerUp = Input.GetKeyUp("space");

		if (triggerDown) {
			FindObjectOfType<AudioManager>().PlayLoop();
		}

		if (triggerUp) {
			FindObjectOfType<AudioManager>().EndLoop();
		}

		FindObjectOfType<AudioManager>().ChangePitch(GameObject.Find("Camera/trombonematte/TromboneSlide").GetComponent<SlideMovement>().distance);
	}
}
