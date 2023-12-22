using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSkill : Skill
{
    public float radius;
    public float damage;

    private void Awake()
    {
        skillType = SkillType.Active;
    }

    private void OnEnable()
    {
        Area area = PoolManager.Instance.GenerateObject(PoolType.Area).GetComponent<Area>();
        area.damage = damage;
        area.transform.localScale = new Vector3(radius, radius, 0);
        area.gameObject.SetActive(true);
    }

}
