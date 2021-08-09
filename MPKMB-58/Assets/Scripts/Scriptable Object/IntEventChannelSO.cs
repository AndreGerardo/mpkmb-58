using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Int Event Channel")]
public class IntEventChannelSO : ScriptableObject
{
    public UnityAction<int> onEventRaised;
    public void RaiseEvent(int number)
    {
        if (onEventRaised != null)
            onEventRaised.Invoke(number);
        else
            Debug.LogWarning("Event Raised, but no one picked it up");
    }
}
