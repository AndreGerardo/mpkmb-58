using System.Collections;
using UnityEngine;

public class NPCv4 : Item
{
    [SerializeField] DialogueObject afterDialogue;
    [SerializeField] DialogueActivator dialogActivator;
    [SerializeField] string QuizCompleted;

    public override void Interact()
    {
        StartCoroutine(ChangeDialogue(0.5f));
    }

    IEnumerator ChangeDialogue(float delayTime)
    {
        /*ubah DataDialogue di DialogActivator Item / NPC dengan DataDialogue yang baru*/
        dialogActivator.UpdateDialogueObject(afterDialogue);

        yield return new WaitForSeconds(delayTime);
        dialogActivator.gameObject.tag = "Done";
    }
}
