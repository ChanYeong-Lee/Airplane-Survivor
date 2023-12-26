using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        Score = 0;
        killCount = 0;
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
        level = 1;
        maxExp = 50;
    }

    public UnityEvent<float> onHPChange;
    public UnityEvent<float> onExpChange;
    public UnityEvent<int> onLevelChange;
    public UnityEvent<int> onKillChange;
    public UnityEvent<int> onScoreChange;
    public UnityEvent onDie;

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
    private bool isDamaging;
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

    public float currentExp;
    public float CurrentExp
    {
        get { return currentExp; }
        set { currentExp = value; while (currentExp >= maxExp) { currentExp -= maxExp; LevelUp(); } onExpChange?.Invoke(currentExp / maxExp); } 
    }
    public float maxExp;
    private int score;
    public int Score { get { return score; } set { score = value; onScoreChange?.Invoke(score); } }
    private int killCount;
    public float surviveTime;
    public int KillCount { get { return killCount; } set { int killAmount = value - killCount; killCount = value; if(killAmount > 0) Score += killAmount; onKillChange?.Invoke(killCount); } }
    public void TakeDamage(float damage)
    {
        if (!isDamaging)
        {
            CurrentHP -= damage;
            StartCoroutine(InvinsibleCoroutine());
        }
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
        maxExp += 100;
        onLevelChange?.Invoke(level);
    }
    
    private void Die()
    {
        alive = false;
        onDie?.Invoke();
    }

    private IEnumerator InvinsibleCoroutine()
    {
        isDamaging = true;
        yield return new WaitForSeconds(1f);
        isDamaging = false;
    }

    
}
