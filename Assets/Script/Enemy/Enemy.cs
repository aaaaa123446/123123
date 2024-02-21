using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float diePoint;
    public float walkSpeed;
    protected Vector3 rightScale = new Vector3(1, 1, 1);
    protected Vector3 leftScale = new Vector3(-1, 1, 1);
    public LayerMask player;
    public float radius;
    public Transform playerTransform;
    public Vector3 direction;
    public float chaseSpeed;
    float x;float y;
    public PhysicCheck physicsCheck;
    protected Animator ani;
    public bool isAwait;
    public float MaxAwaitTime;
    [SerializeField]
    protected float awaitTime;
    public FloatEventSO pointEvent;
    public PlayerTypeEventSO backToMenuEvent;
    protected SpriteRenderer spriteRenderer;
    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani=GetComponent<Animator>();
        physicsCheck = GetComponent<PhysicCheck>();
    }
    protected virtual void OnEnable()
    {
        backToMenuEvent.OnEventRaised += BackToMenu;
        Debug.Log(spriteRenderer.color);
    }
    private void OnDisable()
    {
        backToMenuEvent.OnEventRaised -= BackToMenu;
    }
    protected virtual  void  Update()
    {
 
        if(ani.GetCurrentAnimatorStateInfo(0).IsName("Monster3Skill"))
        {
            gameObject.tag = "NoneHurt";
        }
        else
        {
            gameObject.tag = "Enemy";
        }
        Walk();
        TimeCounter();
        
    }
    public bool FoundPlayer()
    {
        var a=Physics2D.OverlapCircle(transform.position,radius,player);
        if (a != null) playerTransform = a.transform;
        return a;
    }
    public virtual void Walk()
    {
        if (!FoundPlayer() && !isAwait)
        {
            ani.SetBool("isChase", false);
            ani.SetBool("isWalk", true);
            if (!ani.GetCurrentAnimatorStateInfo(0).IsName("Die"))
                transform.Translate(transform.right * transform.localScale.x * Time.deltaTime * walkSpeed);
            if (physicsCheck.onLeftWall && transform.localScale.x == -1) Await();
            if (physicsCheck.onRightWall && transform.localScale.x == 1) Await();
        }
   
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,radius);
    }
    public void OnDie()
    {
        ani.SetBool("isDie",true);

    }
    public void Await()
    {
        ani.SetBool("isWalk", false);
        isAwait = true;
        awaitTime = MaxAwaitTime;
    }
    public void DestroyThisGameObject()
    {
        pointEvent.RaiseEvent(diePoint);
        ObjectPool.Instance.PushObject(gameObject);
        
    }
    protected virtual void TimeCounter()
    {
        if (awaitTime > 0) awaitTime -= Time.deltaTime;
      
    }
    public void BackToMenu()
    {
        ObjectPool.Instance.PushObject(gameObject);
    }
}
