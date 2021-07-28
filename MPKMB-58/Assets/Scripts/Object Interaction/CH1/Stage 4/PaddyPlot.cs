using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddyPlot : Item
{
    
    public int stage = 0;
    public Sprite[] paddyStages;

    public override void Interact()
    {
        if (stage == 0 && inventory.CheckActiveItem("hoe"))
        {
            stage++;
        }else if(stage == 1 && inventory.CheckActiveItem("seed"))
        {
            stage++;
        }

        GetComponent<SpriteRenderer>().sprite = paddyStages[stage];
    }

}
