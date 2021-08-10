using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuGudang : Item
{
    public MultiSceneManager multiSceneManager;
    private Transform player;
    public Transform designatedPos;
    public Vector3 designatedScale;
    public Sprite changedSprite;
    public DialogueObject afterDialog;
    public bool toTheRight = true, isUnlocked = false;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        if(multiSceneManager == null)
            multiSceneManager = GetComponentInParent<MultiSceneManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    public override void Interact()
    {
        if(!isUnlocked)
        {
            if(inventory.HasItem("kunci gudang")){
                if (inventory.CheckActiveItem("kunci gudang"))
                {
                    gameObject.GetComponent<DialogueActivator>().UpdateDialogueObject(afterDialog);
                    inventory.RemoveItem("kunci gudang");
                    isUnlocked = true;
                    gameObject.GetComponent<SpriteRenderer>().sprite = changedSprite;
                } else {
                    Debug.Log("Aku harus menggunakan item kunci gudang!");
                }
            }
            return;
        }
        player.position = designatedPos.position;
        player.localScale = designatedScale;

        if (toTheRight)
        {
            GoRight();
        }else if(!toTheRight)
        {
            GoLeft();
        }

    }

    private void GoRight()
    {
        multiSceneManager.BACKGROUND_NUM++;
    }

    private void GoLeft()
    {
        multiSceneManager.BACKGROUND_NUM--;
    }

}
