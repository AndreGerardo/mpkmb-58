using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 100f;
	public float fireRate = 0.15f;
	float timer;

	public bool mobileShootHold;

	// public AudioSource explosion;
	public AudioSource laser;

	Rigidbody2D rb;
	Vector3 touchPosition;

	public Transform gunPos;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		Move ();
		// Clampper ();


		timer += Time.deltaTime;

		if ((Input.GetKey(KeyCode.Space) || mobileShootHold) && timer > fireRate) {
			Shoot ();
			timer = 0;
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.collider.tag == "Enemy") {
			GameManager.GM.playerHealth -= 1;
			// explosion.Play ();
			Destroy (coll.gameObject);
		}
		if (coll.collider.tag == "Obstacle") {
			GameManager.GM.playerHealth -= 1;
			// explosion.Play ();
			Destroy (coll.gameObject);
		}
	}

	void Shoot()
	{
		GameObject obj = (GameObject)Cannon.CN.SpawnBullet ();

		if (obj == null) {
			return;
		}

		// laser.Play ();

		obj.transform.position = gunPos.position;
		// obj.transform.rotation = Quaternion.identity;
		obj.SetActive (true);
	}

	void Move()
	{
		
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if(touch.phase == TouchPhase.Moved)
			{
                touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);

				Vector3 newPos = new Vector3(transform.position.x, touchPosition.y, transform.position.z);
			
				transform.position = newPos;
				mobileShootHold = true;
			}

		}else if(Input.GetMouseButton(0))
		{
				touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				Vector3 newPos = new Vector3(transform.position.x, touchPosition.y, transform.position.z);
			
				transform.position = newPos;
				mobileShootHold = true;
		
		}else
		{
			mobileShootHold = false;
		}

	}

	void Clampper()
	{
		float mapWidth = 2.62f;
		Vector3 playerPos = transform.position;

		playerPos.x = Mathf.Clamp (playerPos.x, -mapWidth, mapWidth);
		transform.position = playerPos;
	}

}
