using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedSkill : Skill
{
    public float amount;
    private Player player;
    private void Awake()
    {
        skillType = SkillType.Passive;
        skillName = SkillName.MoveSpeedSkill;
    }

    private void Start()
    {
        player = GameManager.Instance.player;
        player.move.moveSpeed += amount;
    }

    private void OnDestroy()
    {
        player.move.moveSpeed -= amount;
    }


}
