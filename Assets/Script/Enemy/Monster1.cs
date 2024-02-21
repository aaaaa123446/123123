using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : Enemy
{
    
   
    public override void Walk()
    {
        base.Walk();
        if (FoundPlayer())
        {
            ani.SetBool("isWalk", false);
            ani.SetBool("isChase", true);
            direction = playerTransform.position - transform.position;
            if (direction.x > 0) transform.localScale = rightScale;
            else transform.localScale = leftScale;
            if(!ani.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            transform.Translate(direction * chaseSpeed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - playerTransform.position.x) <= 0.6 && Mathf.Abs(transform.position.y - playerTransform.position.y) <= 0.6)
            {
                ani.SetBool("isAtk", true);
            }
            else
            {
                ani.SetBool("isAtk", false);
            }
        }
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
