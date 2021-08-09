using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

	public float speed;

	void Update()
	{
		Vector2 offsetY = new Vector2 (speed * Time.time * Time.fixedDeltaTime, 0);

		GetComponent<SpriteRenderer>().material.mainTextureOffset = offsetY;
	}
}
