using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovementInside : MultiSceneManager
{

    public GameObject mainMultiSceneManager;
    public override void SceneChange()
    {
        if(prevBGNum != BACKGROUND_NUM)
        {
            bg.sprite = backgrounds[BACKGROUND_NUM];

            foreach (var item in backgroundCollections)
            {
                item.SetActive(false);
            }

            backgroundCollections[BACKGROUND_NUM].SetActive(true);

            prevBGNum = BACKGROUND_NUM;

            if(BACKGROUND_NUM > 0)
            {
                mainMultiSceneManager.SetActive(false);
            }else
            {
                mainMultiSceneManager.SetActive(true);
            }

            if(BACKGROUND_NUM != backgrounds.Count-1 && BACKGROUND_NUM != 0)
            {
                leftArrow.SetActive(true);
                rightArrow.SetActive(true);
            }
            if(BACKGROUND_NUM == 0)
            {
                leftArrow.SetActive(false);
                rightArrow.SetActive(true);
            }
            if(BACKGROUND_NUM == backgrounds.Count-1)
            {
                leftArrow.SetActive(true);
                rightArrow.SetActive(false);
            }
        }
    }
}
