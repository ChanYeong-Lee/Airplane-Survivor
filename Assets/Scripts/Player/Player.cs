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

    // Events
    [HideInInspector] public UnityEvent<float> onHPChange;
    [HideInInspector] public UnityEvent<float> onExpChange;
    [HideInInspector] public UnityEvent<int> onLevelChange;
    [HideInInspector] public UnityEvent<int> onKillChange;
    [HideInInspector] public UnityEvent<int> onScoreChange;
    [HideInInspector] public UnityEvent onDie;
    [HideInInspector] public UnityEvent<bool> sprintPrepared;

    // Settings
    public PlayerMove move;
    public PlayerRotation rotation;
    public Transform skillsParent;
    private SpriteRenderer spriteRenderer;
    public bool Alive { get { return alive; } }
    private bool isDamaging;

    [HideInInspector] public Ship ship;

    [HideInInspector] public List<Skill> skillList;

    [HideInInspector] public bool isMoving;
    [HideInInspector] private bool alive;
    
    [HideInInspector] public int level;
    [HideInInspector] public float damage;
    [HideInInspector] private float currentHP;
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

    [HideInInspector] public float currentExp;
    public float CurrentExp
    {
        get { return currentExp; }
        set { currentExp = value; if (currentExp >= maxExp) { currentExp -= maxExp; LevelUp(); } onExpChange?.Invoke(currentExp / maxExp); } 
    }

    [HideInInspector] public float maxExp;
    private int score;
    public int Score { get { return score; } set { score = value; onScoreChange?.Invoke(score); } }

    private int killCount;
    public int KillCount { get { return killCount; } set { int killAmount = value - killCount; killCount = value; if(killAmount > 0) Score += killAmount; onKillChange?.Invoke(killCount); } }

    public void TakeDamage(float damage)
    {
        if (!isDamaging)
        {
            CurrentHP -= damage;
            GameManager.Instance.takenDamage += damage;
            StartCoroutine(InvinsibleCoroutine());
        }
    }

    public void TakeHeal(float amount)
    {
        CurrentHP += amount;
    }

    public void GainExp(float exp)
    {
        StartCoroutine(GainEXPCoroutine(exp));
    }

    private void LevelUp()
    {
        level++;
        MaxHP += 10;
        CurrentHP += 20;
        damage += 1.5f;
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
    private IEnumerator GainEXPCoroutine(float exp)
    {
        for (int i = 0; i < 40; i++)
        {
            CurrentExp += exp / 40;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
