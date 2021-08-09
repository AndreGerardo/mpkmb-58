using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : Item
{
    public MultiSceneManager multiSceneManager;
    private Transform player;
    public Transform designatedPos;
    public Vector3 designatedScale;
    public bool toTheRight = true;

    private void Start()
    {
        if(multiSceneManager == null)
            multiSceneManager = GetComponentInParent<MultiSceneManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    public override void Interact()
    {
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
