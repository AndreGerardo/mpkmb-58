﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public List<DialogueActivator> objectsToInteract;
    public GameObject dialogueBox;
    [SerializeField] private int currentBuildIndex;
    [Header("Scene Manajement")]
    [SerializeField] private SceneManagement sceneManagement;
    [SerializeField] private int moveToScene;
    void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllInteracted())
            StartCoroutine(delayChangeScene(moveToScene,0.5f));
    }

    private bool isAllInteracted(){
        foreach (DialogueActivator dialogueActivator in objectsToInteract)
        {
            if(dialogueActivator.isInteracted == false){
                return false;
            }
        }
        if(dialogueBox.activeSelf == false)
            return true;
        else
            return false;
    }

    private IEnumerator delayChangeScene(int sceneIndex, float time){
        yield return new WaitForSeconds(time);
        sceneManagement.MoveScene(sceneIndex);
    }
}
