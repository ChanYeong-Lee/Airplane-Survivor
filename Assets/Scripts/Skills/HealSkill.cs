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
    }

    private void Start()
    {
        player = GameManager.Instance.player;
    }

    IEnumerator HealCoroutine()
    {
        player.TakeHeal(amount);
        yield return new WaitForSeconds(healRate);
    }
}
