using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChapter6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CH", 6);
    }
}
