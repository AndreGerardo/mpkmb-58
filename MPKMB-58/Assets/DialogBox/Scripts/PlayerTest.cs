using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    private const float MovSpd = 10f;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //biar player gk gerak pas dialogbox muncul
        if (dialogueUI.IsOpen) return;

        //Input gerak
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb.MovePosition(rb.position + input.normalized * (MovSpd * Time.fixedDeltaTime));

        //klik objek buat interaksi
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) || Input.touches.Any(x => x.phase == TouchPhase.Began))
        {
            Interactable?.Interact(this);
        }
    }
}































































