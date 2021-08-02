using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IRT : Item
{
    public override void Interact()
    {
        if (gameObject.tag == "Done")
            Debug.Log("Done interact with " + gameObject.name);
    }
}