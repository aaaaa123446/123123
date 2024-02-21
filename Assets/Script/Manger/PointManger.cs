using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PointManger : MonoBehaviour
{
    public PlayerTypeEventSO startEvent1;
    public PlayerTypeEventSO startEvent2;
    private bool isCatchFirstWeapon;
    private bool isCatchSecondWeapon;
    public Transform player1;
    public Transform player2;
    public Transform playerTran;
    public GameObject GreatWeapon;
    public GameObject FantasticWeapon;
    public TextMeshProUGUI TextMeshProUGUI;
    public bool isLoadingMap2;
    public float point;
    public FloatEventSO floatEventSO;
    public PlayerTypeEventSO ToMap2Event;
    public UnityEvent victroy;
    public bool cantVictory;
    private void OnEnable()
    {
        floatEventSO.OnEventRaised += GetPoint;
        startEvent1.OnEventRaised += ChoosePlayer1;
        startEvent2.OnEventRaised += ChoosePlayer2;
    }
    private void OnDisable()
    {
        floatEventSO.OnEventRaised -= GetPoint;
        startEvent1.OnEventRaised -= ChoosePlayer1;
        startEvent2.OnEventRaised -= ChoosePlayer2;
    }
    public void ChoosePlayer1()
    {
        isCatchSecondWeapon = false;
        cantVictory = false;
        isCatchFirstWeapon = false;
        isLoadingMap2 = false;
        playerTran = player1;
        point = 0;
        TextMeshProUGUI.text = point.ToString();
    }
    public void ChoosePlayer2() 
    {
        isCatchSecondWeapon = false;
        cantVictory = false;
        isCatchFirstWeapon = false;
        isLoadingMap2 = false;
        playerTran = player2;
        point = 0;
        TextMeshProUGUI.text = point.ToString();
    }
    public void GetPoint(float point)
    {
        this.point += point;
        TextMeshProUGUI.text = this.point.ToString();
    }
    private void Update()
    {
        if(point>=10&&!isCatchFirstWeapon)
        {
           var a= ObjectPool.Instance.GetObject(GreatWeapon);
            a.transform.position=playerTran.transform.position;
            isCatchFirstWeapon = true;
        }
        if(point>=30&&!isCatchSecondWeapon)
        {
            var a = ObjectPool.Instance.GetObject(FantasticWeapon);
            a.transform.position = playerTran.transform.position;
            isCatchSecondWeapon = true;
        }
        if(point==13&&!isLoadingMap2)
        {
            ToMap2Event.RaiseEvent();
            isLoadingMap2 = true;
        }
        if (point >= 50&&!cantVictory)
        {
            victroy.Invoke();
            cantVictory = true;
        }
    }
}
