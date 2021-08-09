using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Save/Saved Game")]
public class SaveScriptableObject : ScriptableObject
{
    public int Chapter;

    void SaveGame(int currentChapter)
    {
        Chapter = currentChapter;
    }
}
