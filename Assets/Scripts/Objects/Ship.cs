using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public string shipName;
    [TextArea] public string description;
    public Sprite shipIcon;
    public float damage;
    public float maxHP;
    public float moveSpeed;
    public float rotatingSpeed;
    public SkillName startSkill;
}
