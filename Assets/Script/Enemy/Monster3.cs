using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : Enemy
{
    public bool inAtkIEnumerator;
    public float atkRate;
    public float atkDuration;
    protected override void OnEnable()
    {
        base.OnEnable();
        inAtkIEnumerator = false;
    }
    public override void Walk()
    {
        base.Walk();
       if(FoundPlayer())
        {
            ani.SetBool("isWalk", false);
            ani.SetBool("isChase", true);
            direction = playerTransform.position - transform.position;
            if (direction.x > 0) transform.localScale = rightScale;
            else transform.localScale = leftScale;
            if (!ani.GetCurrentAnimatorStateInfo(0).IsName("Die"))
             transform.Translate(direction * chaseSpeed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - playerTransform.position.x) <= 0.7 && Mathf.Abs(transform.position.y - playerTransform.position.y) <= 0.7&&!inAtkIEnumerator)
            {
                inAtkIEnumerator = true;
                StartCoroutine(Atk());
            }

      
        }
    }
    IEnumerator Atk()
    {
        ani.SetTrigger("skill");
        yield return new WaitForSeconds(atkRate);
        inAtkIEnumerator = false;
        
    }
    protected override void TimeCounter()
    {
        base.TimeCounter();
        if (awaitTime <= 0 && isAwait)
        {
            isAwait = false;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            if (!FoundPlayer()) ani.SetBool("isWalk", true);
        }
    }

}
