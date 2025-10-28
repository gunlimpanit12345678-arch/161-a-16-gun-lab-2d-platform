using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public Ishootable Shooter;

    public abstract void Move();
    public abstract void OnHitWith(Charater charater);

    public void InitWeapon(int newDamage,Ishootable newShooter) 
    {
     damage = newDamage;
        Shooter = newShooter;
    }
    public int GetShootDirection() 
    {
     float value = Shooter.Shootpoint.position.x - Shooter.Shootpoint.parent.position.x;

        if (value > 0)
            return 1;
        else return -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Charater character = other.GetComponent<Charater>();
        if (character != null)
        {
            OnHitWith(other.GetComponent<Charater>());
            Destroy(this.gameObject, 5f);
        }
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
