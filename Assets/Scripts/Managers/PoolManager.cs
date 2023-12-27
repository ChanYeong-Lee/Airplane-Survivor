using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PoolType
{
    Bullet,
    Planet,
    Area,
    Enemy
}

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;
    public static PoolManager Instance
    { 
        get
        {
            if (instance == null)
            {
                instance = new GameObject("PoolManager").AddComponent<PoolManager>();
            }
            return instance; 
        } 
    }
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;

        for (int i = 0; i < Enum.GetValues(typeof(PoolType)).Length; i++)
        {
            GameObject parentObject = new GameObject($"{((PoolType)i).ToString()}");
            parentObject.transform.parent = transform;
            parentDictionary.Add((PoolType)i, parentObject.transform);
        }

    }

    public Dictionary<PoolType, Queue<GameObject>> poolDictionary = new Dictionary<PoolType, Queue<GameObject>>
    {
        { PoolType.Bullet, new Queue<GameObject>() },
        { PoolType.Planet, new Queue<GameObject>() },
        { PoolType.Area, new Queue<GameObject>() },
        { PoolType.Enemy, new Queue<GameObject>() },
    };

    public Dictionary<PoolType, Transform> parentDictionary = new Dictionary<PoolType, Transform>();

    public GameObject GenerateObject(PoolType type)
    {
        Queue<GameObject> poolQueue = poolDictionary[type];
        GameObject generatedObject;
        if (poolQueue.Count > 0)
        {
            generatedObject = poolQueue.Dequeue();
        }
        else
        {
            generatedObject = Instantiate(Data.Instance.poolDictionary[type]);
            generatedObject.SetActive(false);
            generatedObject.transform.parent = parentDictionary[type];
        }
        return generatedObject;
    }

    public void RemoveObject(GameObject obj, PoolType type)
    {
        if (obj != null)
        {
            Queue<GameObject> poolQueue = poolDictionary[type];
            obj.transform.parent = parentDictionary[type];
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

}
