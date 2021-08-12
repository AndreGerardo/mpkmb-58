using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperDebug : MonoBehaviour
{
    public void ResetGame()
    {
        PlayerPrefs.SetInt("CH", 1);
        Debug.LogWarning("chapter reset to : " + PlayerPrefs.GetInt("CH"));
    }
}
