using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public CinemachineVirtualCamera virtualCamera;
    public PlayerTypeEventSO playerEvent1;
    public PlayerTypeEventSO playerEvent2;
    private void OnEnable()
    {
        playerEvent1.OnEventRaised += Choose1;
        playerEvent2.OnEventRaised += Choose2;
    }
    private void OnDisable()
    {
        playerEvent1.OnEventRaised -= Choose1;
        playerEvent2.OnEventRaised -= Choose2;
    }
    public void Choose1()
    {
        virtualCamera.Follow = player1.transform;
        virtualCamera.LookAt = player1.transform;
    }
    public void Choose2()
    {
        virtualCamera.Follow = player2.transform;
        virtualCamera.LookAt = player2.transform;
    }
}
