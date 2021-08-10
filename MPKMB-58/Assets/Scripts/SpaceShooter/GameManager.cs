using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
	public static GameManager GM;
	public int playerHealth = 1;
	public int score;
	public int HiScore = 0;
	public TMP_Text scoreText;
	public TMP_Text highScoreText;
	public TMP_Text scoreRealText;
	public TMP_Text timerText;
	public GameObject gameOverCanvas;
	private float gameTime = 60f;

	void Awake()
	{
		if (GM == null) {
			GM = this;
		}else if (GM != this) {
			Destroy (this.gameObject);
		}
	}

	void Start()
	{
		if (PlayerPrefs.HasKey("hiscore")) {
			HiScore = PlayerPrefs.GetInt("hiscore");
		}
	}

	void Update()
	{
		if (playerHealth <= 0 || gameTime == 0) {
			GameOver();
			playerHealth = 1;
		}

		gameTime -= Time.deltaTime;
		timerText.text = "Timer : " + (int)gameTime;
		scoreRealText.text = "SCORE : " + score;
	}

	void HiScoreManager()
	{
		if (score > HiScore) {
			PlayerPrefs.SetInt ("hiscore", score);
			HiScore = score;
		}
	}

	void GameOver()
	{
		GameObject.FindGameObjectWithTag ("Player").SetActive(false);
		HiScoreManager ();
		scoreText.text = "Score : " + score.ToString();
		highScoreText.text = "High Score : " + HiScore.ToString();
		gameOverCanvas.SetActive(true);
	}

	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Next()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

}
