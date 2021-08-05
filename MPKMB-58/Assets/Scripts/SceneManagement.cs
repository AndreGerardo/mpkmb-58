using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//taro di main camera
public class SceneManagement : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        if(GameObject.Find("CrossFade") != null)
            transition = GameObject.Find("CrossFade").GetComponent<Animator>();
    }

    public void CrossFade(int sceneIndex)
    {
        StartCoroutine(loadScene(sceneIndex));
        Debug.Log("crossfade");
    }

    IEnumerator loadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
    //pindah scene
    public void MoveScene(int index)
    {
        CrossFade(index);
    }

    public void NextScene()
    {
        CrossFade(SceneManager.GetActiveScene().buildIndex + 1); //pindah ke index scene selanjutnya
    }
}
