using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Data : MonoBehaviour
{
    private static Data instance;
    public static Data Instance 
    {
        get 
        {
            if (instance == null) 
            { 
                instance = new GameObject("Data").AddComponent<Data>(); 
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
        DontDestroyOnLoad(gameObject);
    }

    public Dictionary<SkillType, Queue<Skill>> skillDictionary = new Dictionary<SkillType, Queue<Skill>>
    {
        { SkillType.ShotSkill, new Queue<Skill>() },
        { SkillType.RevolutionSkill, new Queue<Skill>() },
        { SkillType.AreaSkill, new Queue<Skill>() }
    };

    public List<Skill> shotSkillList = new List<Skill>();
    public List<Skill> revolutionSkillList = new List<Skill>();
    public List<Skill> areaSkillList = new List<Skill>();

    public Dictionary<PoolType, Queue<GameObject>> poolDictionary = new Dictionary<PoolType, Queue<GameObject>>
    {
        { PoolType.Bullet, new Queue<GameObject>() },
        { PoolType.Planet, new Queue<GameObject>() },
        { PoolType.Area, new Queue<GameObject>() },
    };

    public List<GameObject> bulletList = new List<GameObject>();
    public List<GameObject> planetList = new List<GameObject>();
    public List<GameObject> areaList = new List<GameObject>();

    private void Start()
    {

        skillDictionary[SkillType.ShotSkill] = LTQ.ListToQueue(shotSkillList);
        skillDictionary[SkillType.RevolutionSkill] = LTQ.ListToQueue(revolutionSkillList);
        skillDictionary[SkillType.AreaSkill] = LTQ.ListToQueue(areaSkillList);
        poolDictionary[PoolType.Bullet] = LTQ.ListToQueue(bulletList);
        poolDictionary[PoolType.Planet] = LTQ.ListToQueue(planetList);   
        poolDictionary[PoolType.Area] = LTQ.ListToQueue(areaList);   
    }
}
