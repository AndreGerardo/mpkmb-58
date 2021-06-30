using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    protected Inventory inventory;
    public GameObject itemButton;
    [SerializeField]
    private string itemName;
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        // Triggernya
        // Cek apakah kita mengklik object ini
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider == null){
                return;
            }
            // Mengklik Object Tersebut
            if (hit.collider.gameObject.Equals(gameObject)) {
                Interact();
                Debug.Log($"{hit.collider.gameObject.name} diklik!");
            }
        }
    }

    /// <summary>
    /// Panggil ketika item diinteraksi oleh player
    /// </summary>
    public virtual void Interact(){
        MoveToInventory();
    }
    
    /// <summary>
    /// Memindah object ke inventory
    /// </summary>
    /// <returns>True jika berhasil, false jika tidak berhasil</returns>
    protected bool MoveToInventory(){
        Sprite thisObjectSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        // Cek apakah inventory masih kosong
        for (int i = 0; i < inventory.itemSlots.Length; i++)
        {
            // Menemukan yang kosong
            if(inventory.itemSlots[i].IsFull ==false){
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
}
