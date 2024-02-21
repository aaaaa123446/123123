using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public bool isPlayer2;
    public GameObject lowWeapon;
    public GameObject hand;
    public GameObject weapon;
    public GameObject lowBullet;
    public GameObject bullet;
    public Transform weaponHand;
    public SpriteRenderer spriteRenderer;
    private Vector3 mouseDirection;
    private Vector3 mousePos;
    public float walkSpeed;
    public Animator ani;
    public Vector3 rightScale;
    public Vector3 leftScale;
    public GameObject Weapon;
    private bool canCatch;
    public GameObject weaponCanCatch;
    public WeaponType nowWeapon;
    public Vector3 bulletDic;
    public Vector3 bulletdic2;
    public PhysicCheck physicCheck;
    private Rigidbody2D rb;
    public MusicPlay musicPlay2;
    public PlayerTypeEventSO StartEvent1;
    public PlayerTypeEventSO StartEvent2;
    public WeaponManger weaponManger;
    public WeaponTypeEventSO OnWeaponChangeEvent;
    public Player2Only player2Only;
    private void Awake()
    {
        physicCheck=GetComponent<PhysicCheck>();
        nowWeapon = WeaponType.low;
        ani = GetComponent<Animator>();
        rightScale=transform.localScale;
        leftScale = new Vector3(-rightScale.x,rightScale.y,rightScale.z);
        spriteRenderer = weapon.GetComponent<SpriteRenderer>();
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        StartGame();
    }
    private void OnDisable()
    {
      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x>transform.position.x)
        {
            transform.localScale=rightScale;
            weapon.transform.localScale = new Vector3(0.47f, 0.47f, 0.47f);
        }
        else
        {
            transform.localScale = leftScale;
            weapon.transform.localScale = new Vector3(-0.47f,-0.47f,0.47f);
        }
        weapon.transform.right = ((Vector2)mousePos-(Vector2)transform.position).normalized;
    //    weapon.transform.RotateAround(hand.transform.position,Vector3.forward,Input.GetAxis("Mouse Y")*Time.deltaTime*500);
        if(Input.GetMouseButtonDown(0))
        {
            switch (nowWeapon)
            {
                case WeaponType.low:
                    LowAtk(); break;
                case WeaponType.great:
                    GreatAtk(); break;
                case WeaponType.fantastic:
                    FantasticAtk(); break;
                default:
                    break;
            }
            if(isPlayer2)
            {
                player2Only.Atk();
            }
        }
      
            transform.Translate(Input.GetAxis("Vertical")*walkSpeed*Vector3.up*Time.deltaTime);
       
            transform.Translate(Input.GetAxis("Horizontal") * walkSpeed * Vector3.right*Time.deltaTime);
       // physic();
        ani.SetBool("isWalk", Input.GetAxis("Vertical")!=0|| Input.GetAxis("Horizontal")!=0);
        if(canCatch==true&&Input.GetKeyDown(KeyCode.E))
        {
            ChangeWeapon();
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            weaponCanCatch=collision.gameObject;
            canCatch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canCatch=false;
    }
    public void ChangeWeapon()
    {
        if (nowWeapon != WeaponType.low)
        {
            musicPlay2.PlayMusic();
        }
        else
        {
            musicPlay2.StopMusic();
        }


        nowWeapon = weaponCanCatch.GetComponent<Weapon>().type;
        spriteRenderer.sprite = weaponCanCatch.GetComponent<SpriteRenderer>().sprite;
        spriteRenderer.color= weaponCanCatch.GetComponent<SpriteRenderer>().color;
        weaponCanCatch.GetComponent<Weapon>().CatchThis();
        OnWeaponChangeEvent.RaiseEvent(nowWeapon);
        if (nowWeapon != WeaponType.low)
        {
            musicPlay2.PlayMusic();
        }
        else
        {
            musicPlay2.StopMusic();
        }
    }
    public void StartGame()
    {

        nowWeapon =weaponManger.weaponType;
        switch (nowWeapon)
        {
            case WeaponType.low:
                spriteRenderer.sprite = weaponManger.lowWeapon.GetComponent<SpriteRenderer>().sprite;
                spriteRenderer.color = weaponManger.lowWeapon.GetComponent<SpriteRenderer>().color; break;
            case WeaponType.great:
                spriteRenderer.sprite = weaponManger.GreatWeapon.GetComponent<SpriteRenderer>().sprite;
                spriteRenderer.color = weaponManger.GreatWeapon.GetComponent<SpriteRenderer>().color; break;
            case WeaponType.fantastic:
                spriteRenderer.sprite = weaponManger.FantasticWeapon.GetComponent<SpriteRenderer>().sprite;
                spriteRenderer.color = weaponManger.FantasticWeapon.GetComponent<SpriteRenderer>().color;break;
            default:
                break;
        }   
        if (nowWeapon != WeaponType.low)
        {
            musicPlay2.PlayMusic();
        }
        else
        {
            musicPlay2.StopMusic();
        }
        
        
    }
    public void LowAtk()
    {
        var atk = ObjectPool.Instance.GetObject(lowBullet);
        atk.transform.position = weaponHand.transform.position;
        if (transform.localScale.x == 1)
            atk.transform.up = weaponHand.transform.up;
        else
            atk.transform.up = -weaponHand.transform.up;
        atk.GetComponent<Bullet>().direction = weapon.transform.right;
    }
    public void GreatAtk()
    {
        var atk = ObjectPool.Instance.GetObject(bullet);
        atk.transform.position = weaponHand.transform.position;
        atk.GetComponent<Bullet>().direction = weapon.transform.right; 
        
    }
    public void FantasticAtk()
    { 
        var atk = ObjectPool.Instance.GetObject(bullet);
        atk.transform.position = weaponHand.transform.position;
        atk.transform.right=weapon.transform.right;
        atk.GetComponent<Bullet>().direction = weapon.transform.right;
        atk = ObjectPool.Instance.GetObject(bullet);
        atk.transform.position = weaponHand.transform.position;
        atk.transform.right = weapon.transform.right;
        atk.transform.Rotate(Vector3.forward,30);
        atk.GetComponent<Bullet>().direction = atk.transform.right;
        atk = ObjectPool.Instance.GetObject(bullet);
        atk.transform.position = weaponHand.transform.position;
        atk.transform.right = weapon.transform.right;
        atk.transform.Rotate(Vector3.forward, -30);
        atk.GetComponent<Bullet>().direction = atk.transform.right;
       
    }
    //public void physic()
    //{
    //    if(physicCheck.onLeftWall)
    //        rb.velocity = Vector3.zero;
    //}
    public void OnDie()
    {
        ani.SetBool("isDie",true);
        ani.SetTrigger("die");
        enabled = false;
    }
}
