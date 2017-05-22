using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 100;
    private Transform target;
    public GameObject explosionEffectPrefab;

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    void Update()
    {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<Enemy>().TakeDamage(damage);
            GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
