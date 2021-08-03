using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    public List<GameObject> npc;
    public GameObject dialogueBox;
    [SerializeField] private int currentBuildIndex;
    [Header("Scene Manajement")]
    [SerializeField] private SceneManagement sceneManagement;

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

    private bool isAllInteracted()
    {
        foreach (GameObject npc in npc)
        {
            if (npc.gameObject.tag != "Done")
            {
                return false;
            }
        }
        if (dialogueBox.activeSelf == false)
            return true;
        else
            return false;
    }

    private IEnumerator delayChangeScene(float time){
        yield return new WaitForSeconds(time);
        sceneManagement.NextScene();
    }
}
