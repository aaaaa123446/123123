using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2MonsterCreat : MonoBehaviour
{
    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;
    public Vector3 monster1_1Pos;
    public Vector3 monster1_2Pos;
    public Vector3 monster1_3Pos;
    public Vector3 monster2_1Pos;
    public Vector3 monster2_2Pos;
    public Vector3 monster3_1Pos;
    public Vector3 monster3_2Pos;
    private void Start()
    {
      
       var a= ObjectPool.Instance.GetObject(Monster1);
        a.transform.position=monster1_1Pos;
        a= ObjectPool.Instance.GetObject(Monster1);
        a.transform.position=monster1_2Pos;
        a = ObjectPool.Instance.GetObject(Monster1);
        a.transform.position = monster1_3Pos;
        a = ObjectPool.Instance.GetObject(Monster2);
        a.transform.position = monster2_1Pos;
        a = ObjectPool.Instance.GetObject(Monster2);
        a.transform.position = monster2_2Pos;
        a = ObjectPool.Instance.GetObject(Monster3);
        a.transform.position = monster3_1Pos;
        a = ObjectPool.Instance.GetObject(Monster3);
        a.transform.position = monster3_2Pos;
    }
}
