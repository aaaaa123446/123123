using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float timeAppear;
    public Color myColor;
    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myColor = spriteRenderer.color;
    }
    void OnEnable()
    {
        GetComponent<Collider2D> ().enabled = true;
        spriteRenderer.color=myColor;
        timeAppear = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*Time.deltaTime*10,Space.World);
        
    }
    private void FixedUpdate()
    {
        timeAppear -= Time.fixedDeltaTime;
        if (timeAppear <= 0)
        {
          
            ObjectPool.Instance.PushObject(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        {

            GetComponent<Collider2D>().enabled = false;spriteRenderer.color = Color.clear;
        }
    }
}
