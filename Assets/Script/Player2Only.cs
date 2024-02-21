using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Only : MonoBehaviour
{
    public GameObject Muzzle;
    public void Atk()
    {
        Muzzle.SetActive(true);
        StartCoroutine(AtkIEnumerator());
    }
    IEnumerator AtkIEnumerator()
    {
        yield return new WaitForSeconds(0.2f);
        Muzzle.SetActive(false);
    }
}
