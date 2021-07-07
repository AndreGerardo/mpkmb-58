using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private string nameOfSpeaker;
    [SerializeField] [TextArea] private string[] dialogueIsi;
    [SerializeField] private Response[] responses;

    public string NameOfSpeaker => nameOfSpeaker;
    public string[] Dialogue => dialogueIsi;
    public Response[] Responses => responses;

    public bool HasResponses => Responses != null && Responses.Length > 0;
}

