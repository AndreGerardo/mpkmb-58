using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private Dialogue[] dialogue;
    /*[SerializeField] private Sprite speakerSprite;*/
    [SerializeField] private Response[] responses;

    public Dialogue[] Dialogue => dialogue;
    /*public Sprite SpeakerSprite => speakerSprite;*/
    public Response[] Responses => responses;
    public bool HasResponses => Responses != null && Responses.Length > 0;
}

