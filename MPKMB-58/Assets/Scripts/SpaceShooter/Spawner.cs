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
			spawnDelay -= spawnDelay*5f/100f;
			timer = 0;
		}
	}

	void Spawn()
	{
		float mapWidth = 4f;

		Vector3 posY = new Vector3 (transform.position.x, Random.Range(-mapWidth, mapWidth), transform.position.y);

		Instantiate (hostileObj[Random.Range(0,hostileObj.Length)], posY, Quaternion.identity);
	}

}
