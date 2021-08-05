using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : Item
{
    private MultiSceneManager multiSceneManager;
    private Transform player;
    public Transform designatedPos;
    public bool toTheRight = true;

    private void Start()
    {
        multiSceneManager = GetComponentInParent<MultiSceneManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
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
