using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpeedSkill : Skill
{
    public float amount;
    private Player player;
    private void Awake()
    {
        skillType = SkillType.Passive;
        skillName = SkillName.RotatingSpeedSkill;
    }

    private void Start()
    {
        player = GameManager.Instance.player;
        player.rotation.rotatingSpeed += amount;
    }

    private void OnDestroy()
    {
        player.rotation.rotatingSpeed -= amount;
    }
}
