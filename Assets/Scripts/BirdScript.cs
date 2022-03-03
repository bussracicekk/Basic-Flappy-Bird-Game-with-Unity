using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
	public static BirdScript instance;

	[SerializeField]
	private Rigidbody2D Rbody2D;

	[SerializeField]
	private Animator Anim;
	private float speed = 3f;
	private float bounceSpeed = 4f;

	private bool didFlap;
	public bool isAlive;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip flapclip, dieClip, pointClip;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
		isAlive = true;
		SetCameraX();
	}
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (isAlive) {
			Vector3 tmp = transform.position;
			tmp.x += speed * Time.deltaTime; //actually writing speed is enough but if we write deltaTime then this vode run without bug.
			transform.position = tmp;
			if(didFlap) {
				didFlap = false;
				Rbody2D.velocity = new Vector2(0,bounceSpeed);
				audioSource.PlayOneShot (flapclip);
				Anim.SetTrigger ("flap");
			}
			if (Rbody2D.velocity.y>=0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				float angle = 0;
				angle = Mathf.Lerp (0, -90, -Rbody2D.velocity.y / 7);
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}
		}


	}
	public float GetPositionX(){
		return transform.position.x;
	}

	void SetCameraX(){
		CameraScript.setx = (Camera.main.transform.position.x-transform.position.x)-1f;
	}
		
	public void jump(){
		didFlap=true;		
	}

	void OnCollisionEnter2D(Collision2D Target){
		if (Target.gameObject.tag == "Ground" || Target.gameObject.tag == "Pipe") {
			if (isAlive) {
				isAlive = false;
				Anim.SetTrigger ("birddied");
				audioSource.PlayOneShot (dieClip);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D Target){
		if (Target.gameObject.tag == "PipeHolder"){
			audioSource.PlayOneShot (pointClip);
		}
	}
			
}