using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk : MonoBehaviour
{
    public float atk;
    public string enemy;
    public PlayerTypeEventSO playerTypeEventSO;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag(enemy))
        {
            collision.GetComponent<Character>()?.takeDamage(atk);
            playerTypeEventSO?.RaiseEvent();
        }
    }
}
