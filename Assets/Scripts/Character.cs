using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charater : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int health;

    public int Health
    { get => health;
        set => health = (value < 0) ? 0 : value; }

    private int maxHealth;

    protected Animator anim;
    protected Rigidbody2D rb;
    [SerializeField] HealthBar healthBar;

    public void Initialize(int startHealth)
    {
        Health = startHealth;
        maxHealth = startHealth;
        Debug.Log($"{this.name} initial Health : {this.health}.");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<HealthBar>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.UpdateHealthBar(Health, maxHealth);
        Debug.Log($"{this.name} took damage {damage}. Current Health {Health}");
        IsDead();
    }

    public bool IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead and destroy.");
            return false;
        }
        else return false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
