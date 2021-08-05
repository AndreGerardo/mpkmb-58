using System.Collections;
using UnityEngine;

public class EventNPC : Item
{
    [SerializeField] DialogueObject afterDialogue;
    [SerializeField] DialogueActivator dialogActivator;
    [SerializeField] string itemCollected;

    public override void Interact()
    {
        StartCoroutine(ChangeDialogue(0.5f));
        StartCoroutine(DestroyNPC());
    }

    IEnumerator ChangeDialogue(float delayTime)
    {
        /*ubah DataDialogue di DialogActivator Item / NPC dengan DataDialogue yang baru*/
        dialogActivator.UpdateDialogueObject(afterDialogue);
        Debug.Log("Kamu mendapatkan : " + itemCollected);

        yield return new WaitForSeconds(delayTime);
        dialogActivator.gameObject.tag = "IRT";
    }

    //Hancurkan objek saat dialog selesai
    IEnumerator DestroyNPC()
    {
        yield return new WaitForSeconds(0.15f);

        DialogueUI dialogUI = FindObjectOfType<DialogueUI>();
        yield return new WaitUntil(() => !dialogUI.IsOpen);

        Destroy(gameObject);
    }
}
