using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {
	private GameObject[] BackGround;
	private GameObject[] Ground;
	private float lastBckX;
	private float lastGrndX;
	void Awake(){
		BackGround = GameObject.FindGameObjectsWithTag ("Background");
		Ground = GameObject.FindGameObjectsWithTag ("Ground");

		lastBckX = BackGround [0].transform.position.x;
		lastGrndX = Ground [0].transform.position.x;

		for (int i = 1; i < BackGround.Length; i++) {
			if (lastBckX < BackGround [i].transform.position.x) {
				lastBckX = BackGround [i].transform.position.x;
			}
		}
		for (int j = 1; j < Ground.Length; j++) {
			if (lastGrndX < Ground [j].transform.position.x) {
				lastGrndX = Ground [j].transform.position.x;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D Target){
		if (Target.tag == "Background") {
			Vector3 tmp = Target.transform.position;
			float width = ((BoxCollider2D)Target).size.x;
			tmp.x = width + lastBckX;
			Target.transform.position = tmp;
			lastBckX = tmp.x;
		}else if(Target.tag == "Ground"){
			Vector3 tmp = Target.transform.position;
			float width = ((BoxCollider2D)Target).size.x;
			tmp.x = width + lastGrndX;
			Target.transform.position = tmp;
			lastGrndX = tmp.x;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
