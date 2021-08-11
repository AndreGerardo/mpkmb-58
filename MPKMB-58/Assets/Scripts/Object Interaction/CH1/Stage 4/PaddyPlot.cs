using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddyPlot : Item
{
    public float delayScene = 1f;
    public int stage = 0;
    public Sprite[] paddyStages;
    public DialogueObject[] dialogueObjectChanges;
    public override void Interact()
    {
        if (stage == 0 && inventory.CheckActiveItem("hoe"))
        {
            GetComponent<DialogueActivator>().UpdateDialogueObject(dialogueObjectChanges[0]);
            stage++;
        }else if(stage == 1 && inventory.CheckActiveItem("seed"))
        {
            GetComponent<DialogueActivator>().UpdateDialogueObject(dialogueObjectChanges[1]);
            stage++;
        }

        GetComponent<SpriteRenderer>().sprite = paddyStages[stage];

        if(stage == 2)
        {
            gameObject.tag = "SemiDone";
            //StartCoroutine(PaddyNext());
        }
    }

    private IEnumerator PaddyNext()
    {
        yield return new WaitForSeconds(delayScene);
        GetComponent<SceneManagement>().NextScene();
    }

}
