using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {
	public static GamePlayController exa;

	[SerializeField]
	private Text scoreText, endText, bestScoreText, gameOverText;
	[SerializeField]
	private Button restarButton, PauseButton;
	[SerializeField]
	private GameObject pausePanel;
	[SerializeField]
	private Image[] medalion;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void Pause_Button(){
		SceneManager.LoadScene("Menu");
	}
	public void Menu_Button(){
		SceneManager.LoadScene("Menu");
	}
}
