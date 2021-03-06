using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public List<DialogueActivator> objectsToInteract;
    public GameObject dialogueBox;
    [SerializeField] private int currentBuildIndex;
    [Header("Scene Management")]
    [SerializeField] private SceneManagement sceneManagement;

    private void Awake() {
        dialogueBox = GameObject.Find("DialogueBox");
    }

    void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllInteracted())
            StartCoroutine(delayChangeScene(0.5f));
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

    private IEnumerator delayChangeScene(float time){
        Debug.Log("next scene");
        yield return new WaitForSeconds(time);
        sceneManagement.NextScene();
    }
}
