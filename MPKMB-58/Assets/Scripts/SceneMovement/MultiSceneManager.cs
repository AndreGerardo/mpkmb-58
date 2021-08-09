using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSceneManager : MonoBehaviour
{
    public SpriteRenderer bg;
    public List<Sprite> backgrounds;
    public List<GameObject> backgroundCollections;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public int BACKGROUND_NUM, prevBGNum;

    private void Start()
    {
        bg = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        prevBGNum = BACKGROUND_NUM;
    }

    private void Update()
    {
        SceneChange();
    }

    public virtual void SceneChange()
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
