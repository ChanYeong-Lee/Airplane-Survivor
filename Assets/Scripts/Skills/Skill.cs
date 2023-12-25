using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int level;
    public Sprite skillIcon;
    [HideInInspector] public SkillType skillType;
    [HideInInspector] public SkillName skillName;
}

public enum SkillName
{
    ShotSkill,
    RevolutionSkill,
    AreaSkill,
    HealSkill,
    MoveSpeedSkill,
    RotatingSpeedSkill,
}

public enum SkillType
{
    Active,
    Passive
}
