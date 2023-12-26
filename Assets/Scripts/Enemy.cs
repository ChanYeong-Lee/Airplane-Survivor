using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image hpBar;

    public float damage;
    public float maxHP;
    private float currentHP;
    public Transform rotation;
    public Chasing chasing;

    [HideInInspector] public UnityEvent<float> onHPChange;
    [HideInInspector] public bool isSprinting;
    [HideInInspector] public Rigidbody2D rb;
    public float CurrentHP { get { return currentHP; }
        set
        {
            currentHP = value;
            if (currentHP <= 0)
            {
                currentHP = 0;
                Die();
            }
            onHPChange?.Invoke(currentHP / maxHP);
        }
    }
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        chasing = GetComponent<Chasing>();
        onHPChange.AddListener(HPBarUpdate);
    }
    private void OnEnable()
    {
        CurrentHP = maxHP;
    }
    public float exp;
    private void Die()
    {
        GameManager.Instance.player.GainExp(exp);
        GameManager.Instance.player.KillCount++;
        PoolManager.Instance.RemoveObject(gameObject, PoolType.Enemy);
    }

    private void HPBarUpdate(float hpAmount)
    {
        hpBar.fillAmount = hpAmount;
    }
    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player target))
        {
            target.TakeDamage(damage);
        }
    }
}

