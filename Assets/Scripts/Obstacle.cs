using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage;
    public float damageRate;

    List<IDamageable> things = new List<IDamageable>();

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
            things.Add(damageable);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
            things.Remove(damageable);
        }
    }
}
