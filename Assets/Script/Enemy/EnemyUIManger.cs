using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManger : MonoBehaviour
{
    public float maxHealthy;
    [SerializeField] 
    private float currentHealth;
    public Image healthImage;
    private void Awake()
    {
        currentHealth=maxHealthy; 
    }
    private void OnEnable()
    {
        healthImage.fillAmount = 1;
        currentHealth = maxHealthy;
    }
    private void Update()
    {
        if (healthImage.fillAmount > currentHealth / maxHealthy)
        {
            if (healthImage.fillAmount - Time.deltaTime < currentHealth / maxHealthy)
                healthImage.fillAmount = currentHealth / maxHealthy;
            else
                healthImage.fillAmount -= Time.deltaTime;
        }
    }
    public void OnHealthyCHange(float health)
    {
        currentHealth = health;
    }
}
