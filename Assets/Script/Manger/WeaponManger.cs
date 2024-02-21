using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManger : MonoBehaviour
{
    public PlayerTypeEventSO backToMenuEvent;
    public WeaponTypeEventSO onWeaponChangeEvent;
    public WeaponType weaponType;
    public GameObject lowWeapon;
    public GameObject GreatWeapon;
    public GameObject FantasticWeapon;
    public void OnEnable()
    {
        onWeaponChangeEvent.onEventRaised += GetWeaponType;
        backToMenuEvent.OnEventRaised += BackToMenu;
    }

    private void OnDisable()
    {
        onWeaponChangeEvent.onEventRaised -= GetWeaponType;
        backToMenuEvent.OnEventRaised -= BackToMenu;
    }
    public void GetWeaponType(WeaponType weaponType)
    {
        this.weaponType = weaponType;
    }
    public void BackToMenu()
    {
        this.weaponType = WeaponType.low;
    }
}
