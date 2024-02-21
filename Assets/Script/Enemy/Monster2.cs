using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : Enemy
{
    public bool inAtkIEnumerator;
    public float atkRate;
    public float atkDuration;
    public GameObject atk;
    private Vector3 flyPosition;
    public float flyRadius;
    public float flySpeed;
    public Vector3 birthPosition;
    protected override void OnEnable()
    {

        inAtkIEnumerator = false;
        birthPosition = transform.position;
        spriteRenderer.color= Color.white;
        base.OnEnable();
        flyPosition=new Vector3(Random.Range(0, flyRadius), Random.Range(0, flyRadius),0)+birthPosition;
    }
    public override  void Walk()
    {
        if (FoundPlayer())
        {
            ani.SetBool("isChase", true);
            direction = playerTransform.position - transform.position;
            if (direction.x > 0) transform.localScale = rightScale;
            else transform.localScale=leftScale;
            if (!ani.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                transform.Translate(direction * chaseSpeed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - playerTransform.position.x) <= 1.5 && Mathf.Abs(transform.position.y - playerTransform.position.y) <= 1.5&&!inAtkIEnumerator)
            {
                
                inAtkIEnumerator = true;
                StartCoroutine(Atk());
            }
        }
        if(!FoundPlayer())
        {
            atk.SetActive(false);
            ani.SetBool("isChase", false);
            if (Mathf.Abs(transform.position.x - flyPosition.x) <= 0.01 && Mathf.Abs(transform.position.y - flyPosition.y) <= 0.01&&!isAwait)
            {
                Await();
              
            }
            direction=flyPosition-transform.position;
            if (direction.x > 0) transform.localScale = rightScale;
            else transform.localScale = leftScale;
            if (!ani.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                transform.Translate(direction*flySpeed*Time.deltaTime);
        }
    }
    IEnumerator Atk()
    {
        atk.SetActive(true);
        yield return  new  WaitForSeconds(atkDuration);
        atk.SetActive(false);
        yield return new WaitForSeconds(atkRate);
        inAtkIEnumerator = false;
    }
    protected override void TimeCounter()
    {
        base.TimeCounter();
        if (awaitTime <= 0 && isAwait)
        {
            isAwait = false;
            float x = Random.Range(0, flyRadius);
            float y = Random.Range(0, flyRadius);
            flyPosition = birthPosition;
            flyPosition.x += x;
            flyPosition.y += y;
        }

    }
}
