using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerChoose : MonoBehaviour
{
    public UIManger uIManger; 
    public PlayerTypeEventSO playerChooseEvent1;
    public PlayerTypeEventSO playerChooseEvent2;
    public GameObject player1;
    public GameObject player2;
    private void OnEnable()
    {
        playerChooseEvent1.OnEventRaised += Choose1;
        playerChooseEvent2.OnEventRaised += Choose2;
    }
    private void OnDisable()
    {
        playerChooseEvent1.OnEventRaised -= Choose1;
        playerChooseEvent2.OnEventRaised -= Choose2;
    }
    public void Choose1()
    {
        player1.SetActive(true);
        uIManger.SetHead(PlayerType.player1);
       
        
    }
    public void Choose2()
    {
        player2.SetActive(true);
        uIManger.SetHead(PlayerType.player2);
    }
}
