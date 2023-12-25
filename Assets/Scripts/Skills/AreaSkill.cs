using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSkill : Skill
{
    public float radius;
    public float damage;
    private Area area;

    private void Awake()
    {
        skillType = SkillType.Active;
        skillName = SkillName.AreaSkill;
    }

    private void Start()
    {
        StartCoroutine(PlanetCoroutine());
    }

    private IEnumerator PlanetCoroutine()
    {
        area = PoolManager.Instance.GenerateObject(PoolType.Area).GetComponent<Area>();
        area.damage = damage;
        area.transform.localScale = new Vector3(radius, radius, 0);
        area.gameObject.SetActive(true);
        PoolManager.Instance.RemoveObject(area.gameObject, PoolType.Area, 1f);
        yield return new WaitForSeconds(1f);
    }

}
