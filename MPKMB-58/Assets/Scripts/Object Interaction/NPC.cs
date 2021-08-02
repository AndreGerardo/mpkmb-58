using UnityEngine;

public class NPC : Item
{
    [Header("Change Dialogue")]
    [SerializeField] DialogueObject afterDialogue;
    [SerializeField] DialogueActivator dialogActivator;
    [SerializeField] string collectedName;
    public bool isTakingItem = false;

    // Overwrite fungsi takeitem milik item dengan menggunakan "override"
    public override void Interact()
    {
        ChangeDialogueByItem();
        if(isTakingItem == true)
        {
            DoneInteract();
        }
    }

    public void ChangeDialogueByItem()
    {
        if (inventory.HasItem(collectedName))
        {
            if (inventory.CheckActiveItem(collectedName))
            {
                dialogActivator.UpdateDialogueObject(afterDialogue);
                inventory.RemoveItem(collectedName);
                isTakingItem = true;
            }
            else
            {
                Debug.Log("Aku harus menggunakan item!");
            }
        }
    }
}
