using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public Player player;
    public Transform playerSkills;

    public ShotSkill skill1;
    public RevolutionSkill skill2;
    public AreaSkill skill3;
    private void Awake()
    {
        Instance = this;
        player = FindObjectOfType<Player>();
    }
    private void Start()
    {
        Instantiate(skill1, playerSkills);
        Instantiate(skill2, playerSkills);
        Instantiate(skill3, playerSkills);
    }
}
