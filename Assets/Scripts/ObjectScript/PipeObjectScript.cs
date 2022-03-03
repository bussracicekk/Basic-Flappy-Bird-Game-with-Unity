using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObjectScript : MonoBehaviour {
	private GameObject[] Holder;
	public float Min, Max;
	private float distance = 2.6f;
	private float lastPipeX;

	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		Holder = GameObject.FindGameObjectsWithTag ("PipeHolder");
		for (int i = 0; i < Holder.Length; i++) {
			Vector3 tmp = Holder[i].transform.position;
			tmp.y = Random.Range (Min, Max);
			Holder[i].transform.position = tmp;
		}
		lastPipeX = Holder[0].transform.position.x;
		for (int j = 0; j < Holder.Length; j++) {
			if (lastPipeX < Holder [j].transform.position.x) {
				lastPipeX = Holder [j].transform.position.x;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D Target){
		if (Target.tag == "PipeHolder") {
			Vector3 tmp = Target.transform.position;
			tmp.x = lastPipeX + distance;
			tmp.y = Random.Range (Min, Max);
			Target.transform.position = tmp;
			lastPipeX = tmp.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
