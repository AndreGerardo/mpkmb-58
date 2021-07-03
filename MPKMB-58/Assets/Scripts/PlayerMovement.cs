using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float moveSpeed = 5f;

    Rigidbody2D rb;

    Animator anim;

    Touch touch;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    bool facingRight = true;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.speed = 1;
    }

    void Update() {

        // Menghitung jarak tujuan dari karakter
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);

            // Karakter bergerak menuju tujuan
            if (touch.phase == TouchPhase.Began) {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * 0);

                // Mengecek jika karakter harus menghadap kanan atau kiri
                if (touchPosition.x > transform.position.x)
                    transform.eulerAngles = new Vector3(0, 0, 0);
                if (touchPosition.x < transform.position.x)
                    transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            previousDistanceToTouchPos = 0;
            currentDistanceToTouchPos = 0;
            isMoving = true;
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;
            whereToMove = (touchPosition - transform.position).normalized;
            rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * 0);

            if (touchPosition.x > transform.position.x)
                transform.eulerAngles = new Vector3(0, 0, 0);
            if (touchPosition.x < transform.position.x)
                transform.eulerAngles = new Vector3(0, -180, 0);
        }

        // Mengecek jika karakter sudah sampai tujuan
        if (currentDistanceToTouchPos > previousDistanceToTouchPos) {
            isMoving = false;
            rb.velocity = Vector2.zero;
            anim.SetInteger("Direction", 0);
        }

        // Mengecek jika karakter bergerak
        if (isMoving) {
            anim.SetInteger("Direction", 1);
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }
    }
}
