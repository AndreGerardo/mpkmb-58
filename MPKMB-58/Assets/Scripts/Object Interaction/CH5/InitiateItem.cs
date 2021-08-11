using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiateItem : Item
{
    [SerializeField] public Sprite[] itemTakenSprite;
    [SerializeField] public string[] itemTaken;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();

        for(int i = 0; i < itemTaken.Length; i++)
        {
            TakeItem(i);
        }
    }

    private void TakeItem(int index)
    {
        // Cek apakah inventory masih kosong
        for (int i = 0; i < inventory.itemSlots.Length; i++)
        {
            // Menemukan yang kosong
            if (inventory.itemSlots[i].IsFull == false)
            {
                // Buat jadi full
                inventory.itemSlots[i].IsFull = true;

                inventory.itemSlots[i].ItemName = itemTaken[index];

                // Ubah UI image jadi sprite object ini
                itemButton.gameObject.GetComponent<Image>().sprite = itemTakenSprite[index];

                // Ubah id
                itemButton.gameObject.GetComponent<Slot>().ID = i;

                // Tambahkan ke UI inventory dan hancurkan gameobject ini
                Instantiate(itemButton, inventory.itemSlots[i].Slot.transform, false);
                return;
            }
        }
    }
}
