using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    public DialogueUI dialogueUI;

    Rigidbody2D rb;

    Animator anim;

    Touch touch;
    Vector2 touchPosition, whereToMove;
    bool isMoving = false;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;
    /// <summary>
    /// mengecek keadaan pemain
    /// </summary>
    [Header("Player State")]
    [SerializeField] private bool isInteracting = false;

    /// <summary>
    /// Mengatur channel event scriptable objest
    /// masukan InteractEvenetChannel ke dalam _voidEventChannelSO
    /// </summary>
    [Header("Configuration")]
    [SerializeField] private VoidEventChannelSO _voidEventChannelSO = default;
    public UnityEvent onEvenRaised;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.speed = 1;
    }

    void Update()
    {
        if (dialogueUI.IsOpen) return;
        // Menghitung jarak tujuan dari karakter
        if (isMoving)
            currentDistanceToTouchPos = (touchPosition - (Vector2)transform.position).magnitude;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            // Karakter bergerak menuju tujuan
            if (touch.phase == TouchPhase.Began)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (touchPosition.y < 3.25f)
                {
                    previousDistanceToTouchPos = 0;
                    currentDistanceToTouchPos = 0;
                    isMoving = true;

                    whereToMove = (touchPosition - (Vector2)transform.position).normalized;
                    rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * 0);

                    // Mengecek jika karakter harus menghadap kanan atau kiri
                    if (touchPosition.x > transform.position.x)
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    if (touchPosition.x < transform.position.x)
                        transform.eulerAngles = new Vector3(0, -180, 0);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {

            isInteracting = true; //player sedang keadaan bergerak

            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPosition.y < 3.25f)
            {
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;

                whereToMove = (touchPosition - (Vector2)transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * 0);

                // Mengecek jika karakter harus menghadap kanan atau kiri
                if (touchPosition.x > transform.position.x)
                    transform.eulerAngles = new Vector3(0, 0, 0);
                if (touchPosition.x < transform.position.x)
                    transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }

        // Mengecek jika karakter sudah sampai tujuan
        if (currentDistanceToTouchPos > previousDistanceToTouchPos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
            anim.SetInteger("Direction", 0);
        }

        // Mengecek jika karakter bergerak
        if (isMoving)
        {
            anim.SetInteger("Direction", 1);
            previousDistanceToTouchPos = (touchPosition - (Vector2)transform.position).magnitude;
        }


        //player melakukan interaksi ketika berhenti
        if (isInteracting && !isMoving)
        {
            Interact();
            isInteracting = false;
        }
    }

    private void Interact()
    {
        Debug.Log("player interact");
        _voidEventChannelSO.RaiseEvent(); // memanggil event
    }
}