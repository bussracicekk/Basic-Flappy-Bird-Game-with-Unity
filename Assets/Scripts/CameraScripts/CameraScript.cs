using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public static float setx;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (BirdScript.instance != null) {
			if (BirdScript.instance.isAlive = true) {
				moveTheCamera ();
			}
		}
			
		
	}
	void moveTheCamera(){
		Vector3 tmp = transform.position;
		tmp.x = BirdScript.instance.GetPositionX();
		transform.position = tmp;
	}
}
