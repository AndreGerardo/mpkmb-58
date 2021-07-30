using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNPC : Item
{
    [SerializeField] DialogueObject afterDialogue;
    [SerializeField] DialogueActivator dialogActivator;
    [SerializeField] string itemCollected;

    public override void Interact()
    {
        /*ubah DataDialogue di DialogActivator Item / NPC dengan DataDialogue yang baru*/
        dialogActivator.UpdateDialogueObject(afterDialogue);
        Debug.Log("Kamu mendapatkan : " + itemCollected);

        //Hancurkan objek saat dialog selesai
        StartCoroutine(DestroyNPC());
    }

    IEnumerator DestroyNPC()
    {
        yield return new WaitForSeconds(0.15f);

        DialogueUI dialogUI = FindObjectOfType<DialogueUI>();
        yield return new WaitUntil(() => !dialogUI.IsOpen);

        Destroy(gameObject);
    }
}
