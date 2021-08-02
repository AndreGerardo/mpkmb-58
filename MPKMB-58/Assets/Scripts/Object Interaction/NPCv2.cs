using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class NPCv2 : NPC
{
    bool hasBeenInteracted = false;
    [Header("Take Item")]
    public Sprite changedSprite;
    public Sprite itemTakenSprite;
    public string itemTaken;

    public override void Interact()
    {
        ChangeDialogueByItem();
        if (hasBeenInteracted == false && isTakingItem == true)
        {
            TakeItem();
            hasBeenInteracted = true;
            isTakingItem = false;
            DoneInteract();
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
