using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : Item
{
    public Transform player;
    public Transform designatedPos;
    public GameObject sceneButtonSwitch;
    public bool toTheRight = true;
    public Sprite changeBackground;
    public SpriteRenderer background;

    void Start()
    {
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        background.sprite = changeBackground;
        player.position = designatedPos.position;
        sceneButtonSwitch.SetActive(true);
        gameObject.SetActive(false);
    }
}
