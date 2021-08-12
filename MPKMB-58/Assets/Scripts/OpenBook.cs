using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject handBook;
    public PauseControl pauseControl;
    public bool isInteracted;
    [Header("Configuration")]
    [SerializeField] private VoidEventChannelSO _voidEventChannelSO = default;
    void Start()
    {
        isInteracted = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _voidEventChannelSO.onEventRaised += Interact; //subcribe channel
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _voidEventChannelSO.onEventRaised -= Interact; //unsubscribe channel
    }

    private void OnDestroy()
    {
        _voidEventChannelSO.onEventRaised -= Interact; //unsubscribe channel
    }

    private void Interact()
    {
        isInteracted = true;
        handBook.gameObject.SetActive(true);
        pauseControl.Pause();
    }
}
