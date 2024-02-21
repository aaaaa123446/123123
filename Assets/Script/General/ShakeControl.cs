using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShakeControl : MonoBehaviour
{
    public CinemachineCollisionImpulseSource source;
    public PlayerTypeEventSO shakeEvent;
    private void OnEnable()
    {
        source=GetComponent<CinemachineCollisionImpulseSource>();
        shakeEvent.OnEventRaised += Shake;
    }
    private void OnDisable()
    {
        shakeEvent.OnEventRaised -= Shake;
    }
    public void Shake()
    {
        source.GenerateImpulse();
    }
}
