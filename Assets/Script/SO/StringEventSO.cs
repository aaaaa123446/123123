using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName ="Event/StringEvent")]
public class StringEventSO : ScriptableObject
{
    public UnityAction<string> OnEventRaised;
    public void RaiseEvent(string context)
    {
        OnEventRaised?.Invoke(context);
    }
}
