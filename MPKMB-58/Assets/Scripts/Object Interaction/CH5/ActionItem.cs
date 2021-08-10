using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionItem : Item
{
    [SerializeField] NPCAdvance toInteract;
    [SerializeField] DialogueActivator dialogActivator;
    [SerializeField] DialogueObject[] afterDialogue;
    public bool isDone = false;
    private int counter = 0;
    public bool disabledAfterInteract = false;
    public override void Interact()
    {
        if(isDone)
        {
            if(counter < afterDialogue.Length)
                ChangeDialog(counter++);
            return;
        }

        if(toInteract.allItemCollected)
        {
            ChangeDialog(counter++);
            for(int i = 0; i < toInteract.collectedName.Length; i++)
            {
                inventory.RemoveItem(toInteract.collectedName[i]);
            }
            isDone = true;
            if(disabledAfterInteract)
                GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void ChangeDialog(int i)
    {
        Debug.Log(i);
        dialogActivator.UpdateDialogueObject(afterDialogue[i]);
    }
}