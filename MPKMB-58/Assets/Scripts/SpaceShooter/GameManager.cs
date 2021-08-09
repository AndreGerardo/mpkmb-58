using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager GM;
	public int playerHealth = 1;
	int defaultHealth = 1;
	public int score;
	public int HiScore = 0;

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
		if (playerHealth <= 0) {
			StartCoroutine (GameOver());
		}
	}

	void HiScoreManager()
	{
		if (score > HiScore) {
			PlayerPrefs.SetInt ("hiscore", score);
			HiScore = score;
		}
	}

	IEnumerator GameOver()
	{
		GameObject.FindGameObjectWithTag ("Player").SetActive(false);
		yield return new WaitForSeconds (1.25f);
		SceneManager.LoadScene (2);
		playerHealth = defaultHealth;
		HiScoreManager ();
	}

}
