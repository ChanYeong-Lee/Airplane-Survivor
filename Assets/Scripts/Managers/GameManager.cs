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
    [HideInInspector] public List<Skill> skillList = new List<Skill>();
    [HideInInspector] public int currentScore;
    [HideInInspector] public int playerLevel;
    [HideInInspector] public int killCount;
    [HideInInspector] public float givenDamage = 0;
    [HideInInspector] public float takenDamage = 0;
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
        Init(); // 나중에 고쳐야함
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
        playerLevel = player.level;
        killCount = player.KillCount;
        time = $"{Clock.Instance.minutes:D2} : {Clock.Instance.seconds:D2}";
        if (currentScore >= highScore)
        {
            highScore = currentScore;
        }
        foreach (Skill skill in player.skillList)
        {
            skillList.Add(skill);
        }
    }

    public void ResetData()
    {
        skillList.Clear();
        currentScore = 0;
        playerLevel = 0;
        killCount = 0;
        givenDamage = 0;
        takenDamage = 0;
        time = null;
    }

    public void GameOver()
    {
        SaveData();
        isPlaying = false;
        SceneLoader.Instance.LoadScene("EndScene");
    }
}
