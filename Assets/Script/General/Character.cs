using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public Animator ani;
    public float maxHealth;
    public float currentHealth;
    public UnityEvent dieEvent;
    public UnityEvent<float> healthChangeEvent;
    private void Awake()
    {
        ani=GetComponent<Animator>();
       
    }
    private void OnEnable()
    {
         currentHealth = maxHealth;
        healthChangeEvent?.Invoke(currentHealth);
    }
    public void takeDamage(float atk)
    {
       
        if (currentHealth - atk <= 0)
        {   
            currentHealth = 0;
            healthChangeEvent?.Invoke(0);
            dieEvent?.Invoke();
            
        }
        else
        {
            ani.SetTrigger("hurt");
            currentHealth -= atk;
            healthChangeEvent?.Invoke(currentHealth);
        }
    }
}
