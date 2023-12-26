using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { if (instance == null) { instance = new GameObject("GameManager").AddComponent<GameManager>(); } return instance; } }

    public bool isPlaying;  // TODO : 나중에 고쳐야함
    public bool prepared = false;

    [HideInInspector] public Player player;
    [HideInInspector] public int shipIndex;
    [HideInInspector] public Dictionary<SkillName, int> skillLevels = new Dictionary<SkillName, int>();
    [HideInInspector] public int currentScore;
    [HideInInspector] public int surviveTime;
    [HideInInspector] public int highScore = 0;
    [HideInInspector] public string time;
  
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
            currentScore = 0;
            player = Instantiate(Data.Instance.playerPrefab);
            FindObjectOfType<CameraMove>().player = player;
            player.ship = Data.Instance.shipPrefabs[shipIndex];
            prepared = true;
            Clock.Instance.StartClock();
        }
    }

    public void SaveData()
    {
        currentScore = player.Score;
        time = $"{Clock.Instance.minutes} : {Clock.Instance.seconds}";
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
        foreach (Skill skill in player.skillList)
        {
            skillLevels.Add(skill.skillName, skill.level);
        }
    }

    public void GameOver()
    {
        SaveData();
        isPlaying = false;
        SceneLoader.Instance.LoadScene("EndScene");
    }
}
