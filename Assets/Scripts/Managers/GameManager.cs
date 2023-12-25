using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { if (instance == null) { instance = new GameObject("GameManager").AddComponent<GameManager>(); } return instance; } }

    public bool isPlaying = true;  // TODO : 나중에 고쳐야함

    [HideInInspector] public Player player;
    [HideInInspector] public int shipIndex;
    [HideInInspector] public Dictionary<SkillName, int> skillLevels = new Dictionary<SkillName, int>();
    [HideInInspector] public int score;
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Init();
    }
    public void Init()
    {
        Debug.Log("Hello");
        if (isPlaying)
        {
            score = 0;
            player = Instantiate(Data.Instance.playerPrefab);
            FindObjectOfType<CameraMove>().player = player;
            player.ship = Data.Instance.shipPrefabs[shipIndex];
        }
    }

    public void SaveData()
    {
        foreach (Skill skill in player.skillList)
        {
            skillLevels.Add(skill.skillName, skill.level);
        }
    }
}
