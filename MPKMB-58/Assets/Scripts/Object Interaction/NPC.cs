using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Item
{
    [SerializeField] DialogueObject afterDialogue;
    [SerializeField] DialogueActivator dialogActivator;
    [SerializeField] string collectedName;

    // Overwrite fungsi takeitem milik item dengan menggunakan "override"
    public override void Interact()
    {
        if (inventory.HasItem(collectedName))
        {
            if (inventory.CheckActiveItem(collectedName))
            {
                dialogActivator.UpdateDialogueObject(afterDialogue);
                inventory.RemoveItem(collectedName);
            }
            else
            {
                Debug.Log("Aku harus menggunakan item!");
            }
        }
    }
}
