using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Data : MonoBehaviour
{
    private static Data instance;
    public static Data Instance { get { if (instance == null) { instance = new GameObject("Data").AddComponent<Data>(); } return instance; } }
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        skillDictionary[SkillName.ShotSkill] = LTQ.ListToQueue(shotSkillList);
        skillDictionary[SkillName.RevolutionSkill] = LTQ.ListToQueue(revolutionSkillList);
        skillDictionary[SkillName.AreaSkill] = LTQ.ListToQueue(areaSkillList);
        skillDictionary[SkillName.HealSkill] = LTQ.ListToQueue(healSkillList);
        poolDictionary[PoolType.Bullet] = bulletPrefab;
        poolDictionary[PoolType.Planet] = planetPrefab;
        poolDictionary[PoolType.Area] = areaPrefab;
    }

    public Player playerPrefab;
    public Ship[] shipPrefabs;

    public Dictionary<SkillName, Queue<Skill>> skillDictionary = new Dictionary<SkillName, Queue<Skill>>
    {
        { SkillName.ShotSkill, new Queue<Skill>() },
        { SkillName.RevolutionSkill, new Queue<Skill>() },
        { SkillName.AreaSkill, new Queue<Skill>() },
        { SkillName.HealSkill, new Queue<Skill>() }
    };

    public List<Skill> shotSkillList = new List<Skill>();
    public List<Skill> revolutionSkillList = new List<Skill>();
    public List<Skill> areaSkillList = new List<Skill>();
    public List<Skill> healSkillList = new List<Skill>();

    public Dictionary<PoolType, GameObject> poolDictionary = new Dictionary<PoolType, GameObject>();

    public GameObject bulletPrefab;
    public GameObject planetPrefab;
    public GameObject areaPrefab;
}
