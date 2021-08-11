using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionItem : Item
{
    [SerializeField] NPCAdvance toInteract;
    [SerializeField] Sprite changedSprite;
    public Vector3 designatedScale, designatedPosition;
    [SerializeField] DialogueActivator dialogActivator;
    [SerializeField] DialogueObject[] afterDialogue;
    public bool isDone = false;
    private int counter = 0;
    public bool disabledAfterInteract = false, changeSpriteAfterAction = false;
    public override void Interact()
    {
        if(isDone)
        {
            if(counter < afterDialogue.Length)
                ChangeDialog(counter++);
            return;
        }

        if(toInteract.CheckItem())
        {
            ChangeDialog(counter++);
            if(toInteract.collectedName.Length > 2)
            {
                // Debug.Log($"index item 2 : {FindIndex(toInteract.collectedName[2])}, index item 1 : {FindIndex(toInteract.collectedName[1])}");
                if(FindIndex(toInteract.collectedName[2]) - FindIndex(toInteract.collectedName[1]) == -1)
                {
                    SwapItem(toInteract.collectedName[2], toInteract.collectedName[1]);
                }
            }

            for(int i = 0; i < toInteract.collectedName.Length; i++)
            {
                inventory.RemoveItem(toInteract.collectedName[i]);
            }
            isDone = true;
            if(disabledAfterInteract)
                GetComponent<SpriteRenderer>().enabled = false;
            if(changeSpriteAfterAction)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = changedSprite;
                gameObject.transform.position = designatedPosition;
                gameObject.transform.localScale = designatedScale;
            }
        }
    }

    private void ChangeDialog(int i)
    {
        Debug.Log(i);
        dialogActivator.UpdateDialogueObject(afterDialogue[i]);
    }

    private int FindIndex(string itemName)
    {
        for (int i = 0; i < inventory.itemSlots.Length; i++)
        {
            if(inventory.itemSlots[i].ItemName == itemName){
                return i;
            }
        }
        return -1;
    }

    private void SwapItem(string itemName1, string itemName2)
    {
        string _name;
        int item1Index = FindIndex(itemName1), item2Index = FindIndex(itemName2);
        // Debug.Log("before");
        // Debug.Log($"itemName1 : {inventory.itemSlots[item1Index].ItemName}, itemName2 : {inventory.itemSlots[item2Index].ItemName}");
        _name = inventory.itemSlots[item1Index].ItemName;
        inventory.itemSlots[item1Index].ItemName = inventory.itemSlots[item2Index].ItemName;
        // Debug.Log($"itemName1 : {inventory.itemSlots[item1Index].ItemName}");
        inventory.itemSlots[item2Index].ItemName = _name;
        // Debug.Log("name swapped");
        // Debug.Log($"itemName1 : {inventory.itemSlots[item1Index].ItemName}, itemName2 : {inventory.itemSlots[item2Index].ItemName}");
    }
}