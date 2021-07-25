using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private DialogueUI dialogueUI;

    [Header("Configuration")]
    [SerializeField] private VoidEventChannelSO _voidEventChannelSO = default;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _voidEventChannelSO.onEventRaised += Interact; //subcribe channel
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _voidEventChannelSO.onEventRaised -= Interact; //unsubscribe channel
    }

    private void OnDestroy()
    {
        _voidEventChannelSO.onEventRaised -= Interact; //unsubscribe channel
    }
    public void Interact()
    {
        foreach (DialogueResponseEvents responseEvents in GetComponents<DialogueResponseEvents>())
        {
            if (responseEvents.DialogueObject == dialogueObject)
            {
                dialogueUI.AddResponseEvents(responseEvents.Events);
                break;
            }
        }
        dialogueUI.ShowDialogue(dialogueObject);
    }
}