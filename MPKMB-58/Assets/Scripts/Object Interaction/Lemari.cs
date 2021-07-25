using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lemari : Item
{
    bool hasBeenInteracted = false;
    public Sprite changedSprite;
    public Sprite itemTakenSprite;
    public string itemTaken;



    public override void Interact()
    {
        if (hasBeenInteracted == false)
        {
            TakeItem();
            hasBeenInteracted = true;
        }
    }

    private bool TakeItem()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = changedSprite;
        hasBeenInteracted = true;
        // Cek apakah inventory masih kosong
        for (int i = 0; i < inventory.itemSlots.Length; i++)
        {
            // Menemukan yang kosong
            if (inventory.itemSlots[i].IsFull == false)
            {
                // Buat jadi full
                inventory.itemSlots[i].IsFull = true;

                inventory.itemSlots[i].ItemName = itemTaken;

                // Ubah UI image jadi sprite object ini
                itemButton.gameObject.GetComponent<Image>().sprite = itemTakenSprite;

                // Ubah id
                itemButton.gameObject.GetComponent<Slot>().ID = i;

                // Tambahkan ke UI inventory dan hancurkan gameobject ini
                Instantiate(itemButton, inventory.itemSlots[i].Slot.transform, false);
                return true;
            }
        }
        return false;
    }
}