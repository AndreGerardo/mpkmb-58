using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	public static Cannon CN;

	public List<GameObject> bulletList;
	public GameObject bulletPrefab;
	public bool canIncreaseBullet = true;
	int bulletCount = 10;

	void Awake()
	{
		CN = this;
	}

	void Start()
	{
		bulletList = new List<GameObject> ();

		for (int i = 0; i < bulletCount; i++) {
			GameObject obj = (GameObject)Instantiate (bulletPrefab);
			obj.SetActive (false);
			bulletList.Add (obj);
		}
	}

	public GameObject SpawnBullet()
	{
		for (int i = 0; i < bulletList.Count; i++) {
			if (bulletList[i].activeInHierarchy == false) {
				return bulletList [i];
			}
		}

		if (canIncreaseBullet) {
			GameObject obj = (GameObject)Instantiate (bulletPrefab);
			bulletList.Add (obj);
			return obj;
		}

		return null;
	}

}
