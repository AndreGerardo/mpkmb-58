using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public bool canBeTouched = false;
    public bool checkPlayer = false;
    protected Inventory inventory;
    public GameObject itemButton;
    [SerializeField]
    public string itemName;
    /// <summary>
    /// Mengatur channel event scriptable objest
    /// masukan InteractEvenetChannel ke dalam _voidEventChannelSO
    /// </summary>
    [Header("Configuration")]
    [SerializeField] private VoidEventChannelSO _voidEventChannelSO = default;


    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    /// <summary>
    /// Panggil ketika item diinteraksi oleh player
    /// </summary>
    public virtual void Interact()
    {
        MoveToInventory();
    }

    /// <summary>
    /// Memindah object ke inventory
    /// </summary>
    /// <returns>True jika berhasil, false jika tidak berhasil</returns>
    protected bool MoveToInventory()
    {
        Sprite thisObjectSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        // Cek apakah inventory masih kosong
        for (int i = 0; i < inventory.itemSlots.Length; i++)
        {
            // Menemukan yang kosong
            if (inventory.itemSlots[i].IsFull == false)
            {
                // Buat jadi full
                inventory.itemSlots[i].IsFull = true;

                inventory.itemSlots[i].ItemName = itemName;

                // Ubah UI image jadi sprite object ini
                itemButton.gameObject.GetComponent<Image>().sprite = thisObjectSprite;

                // Ubah id
                itemButton.gameObject.GetComponent<Slot>().ID = i;

                // Tambahkan ke UI inventory dan hancurkan gameobject ini
                Instantiate(itemButton, inventory.itemSlots[i].Slot.transform, false);
                Destroy(gameObject);
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject.name == this.gameObject.name)
                {
                    canBeTouched = true;
                    Debug.Log("Touched " + hit.collider.gameObject.name);
                }
            }
        }


        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)) && canBeTouched && checkPlayer)
        {
            Interact();
        }


    }

    private void OnMouseDown()
    {
        canBeTouched = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if(canBeTouched)
        {
            Interact();
        }

        checkPlayer = true;
        */
        _voidEventChannelSO.onEventRaised += Interact; //subcribe channel
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("onTrigerExit");
        _voidEventChannelSO.onEventRaised -= Interact; //unsubscribe channel
    }

    private void OnTriggerExit(Collider other)
    {
        //checkPlayer = false;

    }

    private void OnDestroy()
    {
        _voidEventChannelSO.onEventRaised -= Interact; //unsubscribe channel
    }
}