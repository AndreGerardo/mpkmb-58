using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : Item
{
    public Transform player;
    public Transform designatedPos;
    [Header("Change Parameters")]
    public int BACKGROUND_NUM = 1; //Background 1,2 atau,3
    public List<Sprite> backgrounds;
    public List<GameObject> sceneButtons;
    public List<GameObject> backgroundCollections;
    public bool toTheRight = true;
    private SpriteRenderer background;

    void Start()
    {
        background = GameObject.Find("Background").GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        player.position = designatedPos.position;

        if (toTheRight)
        {
            GoRight();
        }else if(!toTheRight)
        {
            GoLeft();
        }

        if(BACKGROUND_NUM != backgrounds.Count && BACKGROUND_NUM != 1)
        {
            sceneButtons[0].SetActive(true);
            sceneButtons[1].SetActive(true);
        }else if(BACKGROUND_NUM == 1)
        {
            sceneButtons[0].SetActive(true);
            sceneButtons[1].SetActive(false);
        }else if(BACKGROUND_NUM == backgrounds.Count)
        {
            sceneButtons[0].SetActive(false);
            sceneButtons[1].SetActive(true);
        }
    }

    private void GoRight()
    {
        background.sprite = backgrounds[BACKGROUND_NUM];

        foreach (var items in backgroundCollections)
        {
            items.SetActive(false);
        }

        backgroundCollections[BACKGROUND_NUM].SetActive(true);
    }

    private void GoLeft()
    {
        background.sprite = backgrounds[BACKGROUND_NUM-2];

        foreach (var items in backgroundCollections)
        {
            items.SetActive(false);
        }

        backgroundCollections[BACKGROUND_NUM-2].SetActive(true);
    }

}
