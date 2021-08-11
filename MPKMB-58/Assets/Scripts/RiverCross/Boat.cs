using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public bool isInteractable = false, isFull = false;
    public SpriteRenderer[] passengerPos;
    public GameObject[] leftBankSheep, rightBankSheep;
    public GameObject[] leftBankWolf, rightBankWolf;
    public Sprite wolfSprite, sheepSprite;
    private bool currentBankPos = true;
    public RiverGameManager RG;
    public int sheep, wolf;
    public GameObject leftCollection, rightCollection;



    void Start()
    {
        RG = GameObject.Find("GameManager").GetComponent<RiverGameManager>();
    }

    void Update()
    {
        if (sheep + wolf == 2)
            isFull = true;
        else
            isFull = false;
    }

    public void AddSheep(bool isLeft)
    {
        if (isFull == false)
        {

            if (isLeft && RG.leftBankSheepCount > 0)
            {
                foreach (var sip in leftBankSheep)
                {
                    if (sip.activeSelf == true)
                    {
                        sip.SetActive(false);
                        break;
                    }
                }

                foreach (var pass in passengerPos)
                {
                    if (pass.sprite == null)
                    {
                        pass.sprite = sheepSprite;
                        break;
                    }
                }

                sheep++;
            }
            else if (!isLeft && RG.rightBankSheepCount > 0)
            {
                foreach (var sip in rightBankSheep)
                {
                    if (sip.activeSelf == true)
                    {
                        sip.SetActive(false);
                        break;
                    }
                }

                foreach (var pass in passengerPos)
                {
                    if (pass.sprite == null)
                    {
                        pass.sprite = sheepSprite;
                        break;
                    }
                }

                sheep++;
            }
        }
    }

    public void AddDog(bool isLeft)
    {
        if (isFull == false)
        {
            if (isLeft && RG.leftBankWolfCount > 0)
            {
                foreach (var sip in leftBankWolf)
                {
                    if (sip.activeSelf == true)
                    {
                        sip.SetActive(false);
                        break;
                    }
                }

                foreach (var pass in passengerPos)
                {
                    if (pass.sprite == null)
                    {
                        pass.sprite = wolfSprite;
                        break;
                    }
                }

                wolf++;
            }
            else if (!isLeft && RG.rightBankWolfCount > 0)
            {
                foreach (var sip in rightBankWolf)
                {
                    if (sip.activeSelf == true)
                    {
                        sip.SetActive(false);
                        break;
                    }
                }

                foreach (var pass in passengerPos)
                {
                    if (pass.sprite == null)
                    {
                        pass.sprite = wolfSprite;
                        break;
                    }
                }

                wolf++;
            }
        }
    }

    public void CrossButton()
    {
        if (sheep > 0 || wolf > 0)
        {
            isInteractable = true;
        }

        if (isInteractable)
        {
            GetComponent<Animator>().SetTrigger("Cross");
            isInteractable = false;
        }
    }

    public void ResetButton()
    {
        leftCollection.SetActive(true); rightCollection.SetActive(false);

        RG.leftBankSheepCount = RG.leftBankWolfCount = 3;
        RG.rightBankSheepCount = RG.rightBankWolfCount = 0;

        GetComponent<Animator>().Rebind();
        GetComponent<Animator>().Play("New State", -1, 0f);

        for(int i = 0; i < 3; i++)
        {
            leftBankSheep[i].SetActive(true);
            leftBankWolf[i].SetActive(true);
            rightBankSheep[i].SetActive(false);
            rightBankWolf[i].SetActive(false);
        }
        currentBankPos = true;
        sheep = 0;
        wolf = 0;
    }

    public void CrossRiver()
    {
        if (currentBankPos == true)
        {
            leftCollection.SetActive(false); rightCollection.SetActive(true);

            for (int i = 0; i < sheep; i++)
            {
                foreach (var sip in rightBankSheep)
                {
                    if (sip.activeSelf == false)
                    {
                        sip.SetActive(true);
                        break;
                    }
                }
            }
            for (int i = 0; i < wolf; i++)
            {
                foreach (var sip in rightBankWolf)
                {
                    if (sip.activeSelf == false)
                    {
                        sip.SetActive(true);
                        break;
                    }
                }
            }

            RG.leftBankSheepCount -= sheep;
            RG.leftBankWolfCount -= wolf;
            RG.rightBankSheepCount += sheep;
            RG.rightBankWolfCount += wolf;

        }
        else
        {
            leftCollection.SetActive(true); rightCollection.SetActive(false);

            for (int i = 0; i < sheep; i++)
            {
                foreach (var sip in leftBankSheep)
                {
                    if (sip.activeSelf == false)
                    {
                        sip.SetActive(true);
                        break;
                    }
                }
            }
            for (int i = 0; i < wolf; i++)
            {
                foreach (var sip in leftBankWolf)
                {
                    if (sip.activeSelf == false)
                    {
                        sip.SetActive(true);
                        break;
                    }
                }
            }

            RG.leftBankSheepCount += sheep;
            RG.leftBankWolfCount += wolf;
            RG.rightBankSheepCount -= sheep;
            RG.rightBankWolfCount -= wolf;
        }

        if (RG.leftBankSheepCount < RG.leftBankWolfCount && RG.leftBankSheepCount != 0 || RG.rightBankSheepCount < RG.rightBankWolfCount && RG.rightBankSheepCount != 0)
        {
            Debug.Log("GameOver");
            RG.GameOver();
        }

        if (RG.rightBankSheepCount + RG.rightBankWolfCount == 6)
        {
            RG.GameWon();
        }

        foreach (var pass in passengerPos)
        {
            pass.sprite = null;
        }

        currentBankPos = !currentBankPos;
        sheep = 0; wolf = 0;
    }

}
