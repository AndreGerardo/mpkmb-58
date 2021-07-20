using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textContent;
    [SerializeField] private TMP_Text textSpeaker;

    public bool IsOpen { get; private set; }

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogueBox();
    }

    //Munculin dialog box ke layar
    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvent(responseEvents);
    }

    //Munculin teks yang ada di array ke layar
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i].content;
            string speaker = dialogueObject.Dialogue[i].speaker;

            textSpeaker.text = "<b>" + speaker;

            /*yield return RunTypingEffectSpeaker(speaker);*/
            yield return RunTypingEffect(dialogue);

            textContent.text = dialogue;

            if(i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;

            //Tombol untuk next dialogue 
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        //Munculin opsi kalo di array dialogue punya opsi
        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponse(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textContent);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            //Stop efek typewriter, kalimat langsung keluar semua
            if (Input.GetMouseButtonDown(0))
            {
                typewriterEffect.Stop();
            }
        }
    }

    //tutup dialog boxnya, biar lebih rapi
    public void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textContent.text = string.Empty;
    }
}






















































