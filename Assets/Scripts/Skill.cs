using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public int level;
}

public enum SkillType
{
    ShotSkill,
    RevolutionSkill,
    AreaSkill
}
