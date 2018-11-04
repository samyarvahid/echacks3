using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlideMovement : MonoBehaviour {

    public int speed = 0;

    [HideInInspector]
    public float distance;

    public static float rotXFromParent;
    public static float rotYFromParent;
    public static float rotZFromParent;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	    //var parentComp = gameObject.GetComponentInParent<transform.eulerAngles>();
	    /*
	    float rotXFromParent = parentComp.x;
	    float rotYFromParent =parentComp.y;
	    float rotZFromParent =parentComp.z;
        */

        rotXFromParent = Camera.main.transform.eulerAngles.x;
	    rotYFromParent=Camera.main.transform.eulerAngles.y;
	    rotZFromParent=Camera.main.transform.eulerAngles.z;
	
	    // get input data from keyboard or controller
	    float moveHorizontal = Input.GetAxis("Mouse X");
	    //float moveVertical = Input.GetAxis("Mouse Y");

	    // update player position based on input
	    Vector3 position = transform.position;
	    /*
	    if (Camera.main.transform.eulerAngles.x > 0){
		
		    position.x += 1;
	    }*/
	    //position.x += moveHorizontal * speed * Time.deltaTime;
    
        float shiftX = moveHorizontal * speed * Time.deltaTime * ((float) (Math.Cos((float)((90+rotYFromParent)* Math.PI/180))));
        float shiftY = moveHorizontal * speed * Time.deltaTime * ((float) (Math.Sin((float)((rotXFromParent)* Math.PI/180))));
        float shiftZ = moveHorizontal * speed * Time.deltaTime * ((float)(Math.Sin((float)((rotYFromParent - 90) * Math.PI / 180))));

        position.x += shiftX;
        position.y += shiftY;
        position.z += shiftZ;

        Vector3 bodyPos = GameObject.Find("TromboneBody").transform.position;

        distance = (float) Math.Sqrt(Math.Pow(position.x - bodyPos.x, 2) + Math.Pow(position.y - bodyPos.y, 2) + Math.Pow(position.z - bodyPos.z, 2));
        
        if (distance > 1f)
        {
            position.x -= shiftX;
            position.y -= shiftY;
            position.z -= shiftZ;
        }
        //position.z += moveHorizontal * speed * Time.deltaTime * (float)(Math.Cos((float)((rotYFromParent)* Math.PI/180)));
        //position.z += moveVertical * speed * Time.deltaTime;
        transform.position = position;
	}
}
