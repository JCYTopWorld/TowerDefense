using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            enemys.Add(collider.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            enemys.Remove(collider.gameObject);
        }
    }

    public float attackTateTime = 1;
    private float timer = 0;
    public GameObject bulletPrefab;
    public Transform firePosition;

    void Start()
    {
        timer = attackTateTime;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (enemys.Count > 0 && timer >= attackTateTime)
        {
            timer -= attackTateTime;
            Attack();
        }
    }

    private void Attack()
    {
        GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
    }
}
