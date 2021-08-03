using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCAdvance : Item
{
    [SerializeField] DialogueActivator dialogActivator;
    [SerializeField] ActionItem toInteract;
    [SerializeField] DialogueObject[] afterDialogue;
    [SerializeField] public string[] collectedName;
    [SerializeField] public Sprite[] itemTakenSprite;
    [SerializeField] public string[] itemTaken;

    private int counter = 0;
    private bool isItemTaken = false, firstTime = true;
    public bool isDone = false;
    public bool allItemCollected = false;

    public override void Interact()
    {
        if(isDone)
        {
            return;
        }

        if(firstTime)
        {
            if(toInteract == null && !isItemTaken && itemTakenSprite.Length != 0) {
                if(!isItemTaken)
                {
                    for(int i = 0; i < itemTakenSprite.Length; i++)
                    {
                        Debug.Log("masuk sini gan");
                        TakeItem(i);
                    }
                }
                isItemTaken = true;
            }
            firstTime = false;
            return;
        } else if (toInteract == null && isItemTaken && itemTakenSprite.Length != 0) {
            ChangeDialog(counter++);
            isDone = true;
        }

        if(collectedName.Length != 0)
        {
            if(toInteract != null && toInteract.isDone)
            {
                ChangeDialog(counter++);
                isDone = true;
                if(!isItemTaken)
                {
                    for(int i = 0; i < itemTakenSprite.Length; i++)
                    {
                        Debug.Log("masuk sini gan");
                        TakeItem(i);
                    }
                }
                isItemTaken = true;
            }

            if(!allItemCollected && CheckItem())
            {
                Debug.Log("Masuk dari");
                ChangeDialog(counter++);
                allItemCollected = true;
            }

        } else {
            if(toInteract != null && toInteract.isDone)
            {
                ChangeDialog(counter++);
                isDone = true;
            }
        }
    }   

    private bool CheckItem()
    {
        bool collected;
        Debug.Log(collectedName.Length);
        for(int i = 0; i < collectedName.Length; i++)
        {
            // Debug.Log("masuk sini ah gan");
            collected = inventory.HasItem(collectedName[i]);
            Debug.Log(collected);
            if(!collected)
            {
                // Debug.Log("ga ada barangnya");
                return false;
            }
        }
        return true;
    }

    private void ChangeDialog(int i)
    {
        Debug.Log(i);
        dialogActivator.UpdateDialogueObject(afterDialogue[i]);
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