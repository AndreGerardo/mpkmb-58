using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIntro : MonoBehaviour
{
    public DialogueActivator dialogueActivator;
    // Start is called before the first frame update
    void Start()
    {
        dialogueActivator.Interact();
    }
}
