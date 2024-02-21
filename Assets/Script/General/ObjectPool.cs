using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ObjectPool
{
    private static ObjectPool instance;
    public static ObjectPool Instance
    {
        get
        {
            if(instance==null)
                instance = new ObjectPool();
            return instance;
        }
    }
    private Dictionary<string,Queue<GameObject>> objectPool = new Dictionary<string,Queue<GameObject>>();
    private GameObject pool;
    public GameObject GetObject(GameObject preferb)
    {
        GameObject _object;
        if (!objectPool.ContainsKey(preferb.name) || objectPool[preferb.name].Count==0)
        {
            _object=GameObject.Instantiate(preferb);
            PushObject(_object);
            if (pool == null)
                pool = new GameObject("ObjectPool");
            GameObject ChildPool=GameObject.Find(preferb.name+"Pool");
            if(!ChildPool)
            {
                ChildPool = new GameObject(preferb.name + "Pool");
                ChildPool.transform.SetParent(pool.transform);
            }
            _object.transform.SetParent(ChildPool.transform);   
        }
        _object = objectPool[preferb.name].Dequeue();
        _object.SetActive(true);
        return _object;
 
    }
    public void PushObject(GameObject preferb)
    {
        string _name = preferb.name.Replace("(Clone)",string.Empty);
        if(!objectPool.ContainsKey(_name))
        {
            objectPool.Add(_name,new Queue<GameObject>());
        }
        objectPool[_name].Enqueue(preferb);
        preferb.SetActive(false);
    }
}
