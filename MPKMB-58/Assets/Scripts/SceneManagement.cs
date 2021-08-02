using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//taro di main camera
public class SceneManagement : MonoBehaviour
{
    //pindah scene
    public void MoveScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
