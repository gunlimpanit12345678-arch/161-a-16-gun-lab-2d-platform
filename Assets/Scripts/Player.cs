using UnityEngine;

public class Player : Charater , Ishootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform Shootpoint { get; set; }
    [field: SerializeField] public float ReloadTime { get; set; }
    [field: SerializeField] public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(100);
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
    }
    private void FixedUpdate()
    {
        WaitTime = Time.fixedDeltaTime;
    }
    private void Update()
    {
        Shoot();
    }

    public void Shoot() 
    {
     if (Input.GetButtonDown("Fire1")&& WaitTime>= ReloadTime)
        { var bullet = Instantiate(Bullet,Shootpoint.position,Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
                banana.InitWeapon(20, this);
            WaitTime = 0.0f;
        }
    }

    public void OnHitWith(Enermie enermy)
    {
        TakeDamage(enermy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enermie enermy = other.gameObject.GetComponent<Enermie>();
        if (enermy != null) 
        {
            OnHitWith(enermy);
            Debug.Log($"{this.name} get hit by {enermy.name}");
        }
    }


    
    
        
    

    void Ishootable.Shoot()
    {
        throw new System.NotImplementedException();
    }
}
