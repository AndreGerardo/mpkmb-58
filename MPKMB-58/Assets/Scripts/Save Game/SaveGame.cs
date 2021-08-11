using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    [SerializeField] private int thisChapter;
    public int chapter;

    [Header("Configuration")]
    [SerializeField] private SaveScriptableObject _saveScriptableObject = default;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().interactable = false;
        chapter = _saveScriptableObject.Chapter;
        if(PlayerPrefs.HasKey("CH"))
            chapter = PlayerPrefs.GetInt("CH");
        CheckChapter();
    }
    
    public void CheckChapter()
    {
        Debug.Log("chapter checked");
        if(thisChapter <= chapter)
        {
            GetComponent<Button>().interactable = true;
        }
    }
    
}
