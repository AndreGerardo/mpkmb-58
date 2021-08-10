using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public bool isInteractable = true;
    public Animator transition;
    public float transitionTime = 1f;
    public int currentStory = 0;
    public Sprite[] stories;
    public Image storyScene;
    

    private void Start()
    {
        storyScene.sprite = stories[0];

        if (GameObject.Find("CrossFade") != null) 
        {
            GameObject.Find("CrossFade").GetComponent<CanvasGroup>().alpha = 1;
            transition = GameObject.Find("CrossFade").GetComponent<Animator>();
        }
            
    }

    private void Update()
    {
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if(currentStory != stories.Length-1 && isInteractable)
                {
                    currentStory++;
                    StartCoroutine(loadStory(currentStory));
                }else
                {
                    isInteractable = false;
                    GetComponent<SceneManagement>().NextScene();
                }
            }
        }else if(Input.GetMouseButtonDown(0))
        {
            if(currentStory != stories.Length-1 && isInteractable)
            {
                currentStory++;
                StartCoroutine(loadStory(currentStory));
            }else
            {
                isInteractable = false;
                GetComponent<SceneManagement>().NextScene();
            }
        }
    }

    IEnumerator loadStory(int storyIndex)
    {
        isInteractable = false;
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        storyScene.sprite = stories[storyIndex];
        transition.SetTrigger("Cut");
        isInteractable = true;
        
    }
}
