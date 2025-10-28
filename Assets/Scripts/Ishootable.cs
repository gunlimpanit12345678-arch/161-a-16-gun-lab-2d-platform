using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ishootable
{
    public GameObject Bullet { get; set; }
    public Transform Shootpoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public void Shoot();
}
