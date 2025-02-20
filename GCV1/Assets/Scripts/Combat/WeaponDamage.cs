using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    private int damage;
    private float knockback;

    private List<Collider> alreadyCollidedWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) { return; }

        if (alreadyCollidedWith.Contains(other)) { return; }

        alreadyCollidedWith.Add(other);

        if (other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);
        }

        if(other.TryGetComponent<ForceReciever>(out ForceReciever forceReciever))
        {
            forceReciever.AddForce((other.transform.position - myCollider.transform.position).normalized * knockback);
        }
    }

    public void SetAttack(int damage, float knoback)
    {
        this.damage = damage;
        this.knockback = knoback;
    }

}
