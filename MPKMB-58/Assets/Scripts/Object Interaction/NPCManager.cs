using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    public List<GameObject> npc;
    public GameObject dialogueBox;
    private int currentBuildIndex;

    void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllInteracted())
        {
            Debug.Log("Goto next scene");
        }
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
}
