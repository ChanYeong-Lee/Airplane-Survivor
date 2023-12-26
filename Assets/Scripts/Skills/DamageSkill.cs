using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSkill : Skill
{
    public float amount;
    private Player player;
    private void Awake()
    {
        skillType = SkillType.Passive;
        skillName = SkillName.DamageSkill;
    }

    private void Start()
    {
        player = GameManager.Instance.player;
        player.damage += amount;
    }

    private void OnDestroy()
    {
        player.damage -= amount;
    }

}
