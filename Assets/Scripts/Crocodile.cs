using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enermie, Ishootable
{
    [SerializeField] private float atkRange;
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform Shootpoint { get; set; }
     public float ReloadTime { get; set; }
     public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(50);
        DamageHit = 30;

        atkRange = 6.0f;
        player= GameObject.FindFirstObjectByType<Player>();

        WaitTime = 0.0f;
        ReloadTime = 5.0f;
    }
    public override void Behavior()
    {
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }
    public void Shoot()
    {
        if (Bullet != null)
        {
            if (WaitTime >= ReloadTime)
            {
                anim.SetTrigger("Shoot");
                var bullet = Instantiate(Bullet, Shootpoint.position, Quaternion.identity);
                Rock rock = bullet.GetComponent<Rock>();
                rock.InitWeapon(30, this);
                WaitTime = 0.0f;
            }
        }
    }

    private void FixedUpdate()
    {
        Behavior();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
