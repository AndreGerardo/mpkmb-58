using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : Item
{
    public Transform player;
    public Transform designatedPos;
    [Header("Change Parameters")]
    public GameObject thisBackgroundGameObjectCollection;
    public GameObject sceneButtonSwitch;
    public GameObject gameObjectCollectionSwitch;
    public bool toTheRight = true;
    public Sprite changeBackground;
    private SpriteRenderer background;

    void Start()
    {
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        background.sprite = changeBackground; //Ganti Background
        player.position = designatedPos.position; //Rubah posisi character

        thisBackgroundGameObjectCollection.SetActive(false); //matiiin collection gameobject background yang sekarang

        sceneButtonSwitch.SetActive(true); //aktifin panah yang lain
        gameObjectCollectionSwitch.SetActive(true); //Aktifin Collection gameobejct yang lain

        gameObject.SetActive(false);
    }
}
