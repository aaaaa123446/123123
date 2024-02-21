using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreate : MonoBehaviour
{
    [SerializeField]
    public GameObject Monster3;
    private float nowTime;
    public GameObject Monster1;
    public GameObject Monster2;
    public Vector3 birthPosition;
    private int MonsterNum;
    public PlayerTypeEventSO MonsterNumEvent;
    private void Awake()
    {
        nowTime = Time.time;
    }
    private void OnEnable()
    {
        MonsterNumEvent.OnEventRaised += OnMonsterDie;
    }
    private void OnDisable()
    {
        MonsterNumEvent.OnEventRaised -= OnMonsterDie;
    }
    private void Update()
    {
        if(Time.time-nowTime>10&&MonsterNum<=8)
        {           
            for(int i = 0; i <=3; i++)
            {
                int l=Random.Range(1,4);
                float y=Random.Range(-0.6f,0.6f);
                switch (l)
                { 
                    case 1:
                       var a= ObjectPool.Instance.GetObject(Monster1);a.transform.position = new Vector3(0,y,0)+birthPosition; break;         
                    case 2:
                        var b = ObjectPool.Instance.GetObject(Monster2); b.transform.position = new Vector3(0, y, 0) + birthPosition; break;
                    case 3:
                        var c = ObjectPool.Instance.GetObject(Monster3); c.transform.position = new Vector3(0, y, 0) + birthPosition; break;
                }

                
            }
            nowTime = Time.time;
            MonsterNum += 3;
        }
    }
    public void OnMonsterDie()
    {
        MonsterNum--;
    }
}
