using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public float bulletSpeed;
	public float lifeTime = 3f;

	void OnEnable()
	{
		Invoke ("SwitchBullet", lifeTime);
	}

	void Update()
	{
		transform.Translate (Vector2.down * bulletSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemy") {
			SwitchBullet ();
			GameManager.GM.score += 1;
			Destroy (coll.gameObject);
		}

		if (coll.tag == "Obstacle") {
			SwitchBullet ();
		}
	}

	void SwitchBullet()
	{
		//Instantiate explosion
		gameObject.SetActive (false);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}
}
