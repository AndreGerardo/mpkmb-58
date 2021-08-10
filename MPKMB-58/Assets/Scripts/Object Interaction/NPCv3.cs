//using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class NPCv3 : NPC
{
    bool hasBeenInteracted = false;
    [Header("Change Other Dialogue")]
    public DialogueObject otherDialogueObject;
    public DialogueActivator otherDialogueActivator;

    public override void Interact()
    {
        ChangeDialogueByItem();
        if (hasBeenInteracted == false && isTakingItem == true)
        {
            ChangeOtherDialogue();
            hasBeenInteracted = true;
            isTakingItem = false;
            DoneInteract();
        }
    }

    private void ChangeOtherDialogue()
    {
        otherDialogueActivator.gameObject.tag = "SemiDone";
        otherDialogueActivator.UpdateDialogueObject(otherDialogueObject);
    }
}
