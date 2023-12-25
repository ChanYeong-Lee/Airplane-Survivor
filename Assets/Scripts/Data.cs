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

        skillDictionary[SkillName.ShotSkill] = shotSkillList;
        skillDictionary[SkillName.RevolutionSkill] = revolutionSkillList;
        skillDictionary[SkillName.AreaSkill] = areaSkillList;
        skillDictionary[SkillName.HealSkill] = healSkillList;
        skillDictionary[SkillName.MoveSpeedSkill] = moveSpeedSkillList;
        skillDictionary[SkillName.RotatingSpeedSkill] = rotatingSpeedSkillList;
        poolDictionary[PoolType.Bullet] = bulletPrefab;
        poolDictionary[PoolType.Planet] = planetPrefab;
        poolDictionary[PoolType.Area] = areaPrefab;
    }

    public Player playerPrefab;
    public Ship[] shipPrefabs;
    public Enemy[] enemyPrefabs;

    public Dictionary<SkillName, List<Skill>> skillDictionary = new Dictionary<SkillName, List<Skill>>
    {
        { SkillName.ShotSkill, new List<Skill>() },
        { SkillName.RevolutionSkill, new List<Skill>() },
        { SkillName.AreaSkill, new List<Skill>() },
        { SkillName.HealSkill, new List<Skill>() },
        { SkillName.MoveSpeedSkill, new List<Skill>() },
        { SkillName.RotatingSpeedSkill, new List<Skill>() }
    };

    public List<Skill> shotSkillList = new List<Skill>();
    public List<Skill> revolutionSkillList = new List<Skill>();
    public List<Skill> areaSkillList = new List<Skill>();
    public List<Skill> healSkillList = new List<Skill>();
    public List<Skill> moveSpeedSkillList = new List<Skill>();
    public List<Skill> rotatingSpeedSkillList = new List<Skill>();

    public Dictionary<PoolType, GameObject> poolDictionary = new Dictionary<PoolType, GameObject>();

    public GameObject bulletPrefab;
    public GameObject planetPrefab;
    public GameObject areaPrefab;
}
