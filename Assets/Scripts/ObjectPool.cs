using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<ParticleSys> poolingObjectQueue = new Queue<ParticleSys>();

     void Awake()
    {
        Instance = this;
        Initialize(10);
    }

    private void Initialize(int initCount)
    {
        for(int i=0;i<initCount;i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private ParticleSys CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<ParticleSys>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;              
    }

    public static ParticleSys GetObject()
    {
        if(Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
                newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(ParticleSys obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
