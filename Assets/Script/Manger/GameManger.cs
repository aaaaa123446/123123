using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public PlayerTypeEventSO ExitEvent;
    private void OnEnable()
    {
        ExitEvent.OnEventRaised += ExitGame;
    }
    private void OnDisable()
    {
        ExitEvent.OnEventRaised -= ExitGame;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
