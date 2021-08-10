using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
	public float lifeTime = 3f;

	void OnEnable()
	{
		Invoke ("SwitchBullet", lifeTime);
	}

	void Update()
	{
		transform.Translate (Vector2.left * enemySpeed * Time.deltaTime);
	}

	void SwitchBullet()
	{
		//Instantiate explosion
		Destroy(gameObject);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}
}
