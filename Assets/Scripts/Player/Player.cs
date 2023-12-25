using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        alive = true;
        spriteRenderer = rotation.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = ship.shipIcon;
        move.moveSpeed = ship.moveSpeed;
        rotation.rotatingSpeed = ship.rotatingSpeed;
        damage = ship.damage;
        MaxHP = ship.maxHP;
        maxExp = 50;
    }

    public UnityEvent<float> onHPChange;
    public UnityEvent<float> onExpChange;
    public UnityEvent<int> onLevelChange;

    public PlayerMove move;
    public PlayerRotation rotation;

    public Ship ship;

    public List<Skill> skillList;
    public Transform skillsParent;
    private SpriteRenderer spriteRenderer;

    [HideInInspector]
    public bool isMoving;
    private bool alive;
    public bool Alive { get { return alive; } }

    public int level;

    public float damage;

    private float currentHP;
    public float CurrentHP 
    { 
        get { return currentHP; }
        set 
        { 
            currentHP = value; 
            if (currentHP > maxHP) { currentHP = maxHP; } 
            if (currentHP <= 0) { currentHP = 0; Die(); } 
            onHPChange?.Invoke(currentHP / maxHP); 
        } 
    }
    private float maxHP;
    public float MaxHP { get { return maxHP; } set { currentHP += value - maxHP; maxHP = value; } }

    private float currentExp;
    public float CurrentExp
    {
        get { return currentExp; }
        set { currentExp = value; while (currentExp >= maxExp) { currentExp -= maxExp; LevelUp(); } onExpChange?.Invoke(currentExp / maxExp); } 
    }
    public float maxExp;

    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;
    }
    public void TakeHeal(float amount)
    {
        CurrentHP += amount;
    }
    public void GainExp(float exp)
    {
        CurrentExp += exp;
    }

    private void LevelUp()
    {
        level++;
        MaxHP += 10;
        damage += 1;
        maxExp += 50;
        onLevelChange?.Invoke(level);
    }
    
    private void Die()
    {
        alive = false;
    }

}
