using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] hostileObj;
	public float spawnDelay = 3f;
	float timer;

	void Update()
	{
		timer += Time.deltaTime;

		if (timer >= spawnDelay) {
			Spawn ();
			timer = 0;
		}
	}

	void Spawn()
	{
		float mapWidth = 2.62f;

		Vector3 posX = new Vector3 (Random.Range(-mapWidth, mapWidth), transform.position.y, transform.position.x);

		Instantiate (hostileObj[Random.Range(0,hostileObj.Length)], posX, Quaternion.identity);
	}

}
