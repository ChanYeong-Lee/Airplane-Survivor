using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealSkill : Skill
{
    public float amount;
    public float healRate;
    private Player player;

    private void Awake()
    {
        skillType = SkillType.Active;
        skillName = SkillName.HealSkill;
    }

    private void Start()
    {
        player = GameManager.Instance.player;
        StartCoroutine(HealCoroutine());
    }

    IEnumerator HealCoroutine()
    {
        player.TakeHeal(amount);
        yield return new WaitForSeconds(healRate);
    }
}
