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
    public Transform head;

    void Start()
    {
        timer = attackTateTime;
    }

    void Update()
    {
        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        timer += Time.deltaTime;
        if (enemys.Count > 0 && timer >= attackTateTime)
        {
            timer = 0;
            Attack();
        }
    }

    private void Attack()
    {
        if (enemys[0] == null) UpdateEnemys();
        if (enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else
        {
            timer = attackTateTime;
        }
    }

    void UpdateEnemys()
    {
        List<int> emptyIndex = new List<int>();
        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                emptyIndex.Add(index);
            }
        }
        for (int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i] - i);
        }
    }
}
