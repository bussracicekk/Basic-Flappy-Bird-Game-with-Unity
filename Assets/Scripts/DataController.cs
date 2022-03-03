using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {
	public static DataController exa;

	private const string High_Score = "High Score";
	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		Object_one();
	}
	void Object_one(){
		if (exa == null) {
			Destroy (gameObject);
		} else {
			exa = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	void gameFirstPlayed(){
		if(PlayerPrefs.HasKey("GameFirsPlayed")){
			PlayerPrefs.SetInt(High_Score,0);
			PlayerPrefs.SetInt("GameFirsPlayed", 0);
			
		}
	}
	public void setHighScore(int score){
		PlayerPrefs.SetInt (High_Score, score);
	}
	public int getHighScore(){
		return PlayerPrefs.GetInt (High_Score);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
