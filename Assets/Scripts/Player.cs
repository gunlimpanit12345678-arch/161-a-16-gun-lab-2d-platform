using UnityEngine;

public class Player : Charater
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialize(100);
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



    // Update is called once per frame
    void Update()
    {
        
    }
}
