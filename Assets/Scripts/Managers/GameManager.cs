using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { if (instance == null) { instance = new GameObject("GameManager").AddComponent<GameManager>(); } return instance; } }

    [HideInInspector] public bool isPlaying = true;  // TODO : 나중에 고쳐야함

    [HideInInspector] public Player player;
    [HideInInspector] public int shipIndex;

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

    private void Start()
    {
        player = Instantiate(Data.Instance.playerPrefab);
        FindObjectOfType<CameraMove>().player = player.transform;
        player.ship = Data.Instance.shipPrefabs[shipIndex];
        Instantiate(Data.Instance.skillDictionary[player.ship.startSkill].Dequeue(), player.skillsParent);
    }
}
