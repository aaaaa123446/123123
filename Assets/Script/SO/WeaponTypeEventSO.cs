using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Event/WeaponTypeEvent")]
public class WeaponTypeEventSO : ScriptableObject
{
    public UnityAction<WeaponType> onEventRaised;
    public void RaiseEvent(WeaponType weaponType)
    {
        onEventRaised?.Invoke(weaponType);
    }
}
