using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaSkill : Skill
{
    public float radius;
    public float DPS;
    private Area area;

    private void Awake()
    {
        skillType = SkillType.Active;
        skillName = SkillName.AreaSkill;
    }

    private void Start()
    {
        float totalDPS = DPS * GameManager.Instance.player.damage; 
        area = PoolManager.Instance.GenerateObject(PoolType.Area).GetComponent<Area>();
        area.DPS = totalDPS;
        area.transform.localScale = new Vector3(radius, radius, 0);
        area.gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        if (area != null)
        {
            PoolManager.Instance.RemoveObject(area.gameObject, PoolType.Area);
        }
    }
}