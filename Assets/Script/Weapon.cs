using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType type;
    public PlayerTypeEventSO backToMenuEvent;
    private void Awake()
    {
       
    }
    private void OnEnable()
    {
        backToMenuEvent.OnEventRaised += CatchThis;
    }
    private void OnDisable()
    {
        backToMenuEvent.OnEventRaised -= CatchThis;
    }
    public void CatchThis()
    {
        ObjectPool.Instance.PushObject(gameObject);
    }
}
