using UnityEngine;

public class IRT : Item
{
    public override void Interact()
    {
        if (gameObject.tag == "IRT")
        {
            gameObject.tag = "Done";
            Debug.Log("Done interact with " + gameObject.name);
        }
    }
}