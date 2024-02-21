using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLoadEvent : ScriptableObject
{
    public UnityAction<SceneSO> OnEventRaised;
    public void RaiseEvent(SceneSO sceneSO)
    {
        OnEventRaised?.Invoke(sceneSO);
    }
}
