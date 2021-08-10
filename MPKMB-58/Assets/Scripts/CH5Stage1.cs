using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH5Stage1 : MonoBehaviour
{
    public NPCAdvance teknisi;
    private bool trigger = true;

    void Update()
    {
        if(teknisi.isDone && trigger)
        {
            StartCoroutine(nextDelay());
            trigger = false;
        }
        
    }

    IEnumerator nextDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<SceneManagement>().NextScene();
    }
}
