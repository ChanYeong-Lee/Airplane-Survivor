using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMoveSpeedSKill : Skill
{
    public float amount;
    private Player player;
    private void Awake()
    {
        skillType = SkillType.Passive;
    }

    private void Start()
    {
        player = GameManager.Instance.player;
    }


}
