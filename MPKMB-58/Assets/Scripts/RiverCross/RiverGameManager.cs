using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RiverGameManager : MonoBehaviour
{
    public int leftBankSheepCount, leftBankWolfCount;
    public int rightBankSheepCount, rightBankWolfCount;
    private int score = 15000;
	private int HiScore = 0;
    private float timer;
    [Header("UI Management")]
    public TMP_Text scoreText;
	public TMP_Text highScoreText;
    public TMP_Text timerText;
    public GameObject gameOverCanvas;

    void Start()
	{
		if (PlayerPrefs.HasKey("hiscoreriver")) {
			HiScore = PlayerPrefs.GetInt("hiscoreriver");
		}
	}

    void Update()
	{
        if(gameOverCanvas.activeSelf == false)
		    timer += Time.deltaTime;
		timerText.text = "Time Taken : " + (int)timer;
	}

    void HiScoreManager()
	{
		if (score > HiScore) {
			PlayerPrefs.SetInt ("hiscoreriver", score);
			HiScore = score;
		}
	}

	public void GameOver()
	{
        score = 0;
        scoreText.text = "Score : " + score.ToString();
		highScoreText.text = "High Score : " + HiScore.ToString();
		gameOverCanvas.SetActive(true);
	}

    public void GameWon()
	{
        score = 15000 - ((15000 * 3 / 1000) * (int)timer);
        if(score < 0) score = 0;
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
