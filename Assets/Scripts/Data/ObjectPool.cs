using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : BaseManager<ObjectPool>
{
    [HideInInspector]
    public List<Bullet> pooledObjects;
    public Bullet objectToPool;

    private int amountInPool;

    private void Start()
    {
        pooledObjects = new List<Bullet>();
        amountInPool = DataManager.Instance.globalConfig.amountInPool;
        Bullet tmp;
        for(int i = 0; i < amountInPool; i++)
        {
            tmp = Instantiate(objectToPool, this.transform, true);
            tmp.Deactive();
            pooledObjects.Add(tmp);
        }
    }

    public Bullet GetPoolObject()
    {
        for(int i = 0; i<amountInPool; i++)
        {
            if (!pooledObjects[i].IsActive)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
