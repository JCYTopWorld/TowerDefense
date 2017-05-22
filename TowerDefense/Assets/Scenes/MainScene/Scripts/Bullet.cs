using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 30;
    public float speed = 100;
    private Transform target;
    public GameObject explosionEffectPrefab;
    private float distanceArriveTarget = 1.2f;
    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    void Update()
    {
        if (target ==null)
        {
            Die();
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Vector3 dir = target.position - transform.position;
        if (dir.magnitude < distanceArriveTarget)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
            Die();
        }
    }

    private void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1f);
        Destroy(this.gameObject);
    }
}
