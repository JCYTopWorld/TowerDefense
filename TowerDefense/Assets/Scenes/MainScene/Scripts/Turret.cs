using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
     
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag=="Enemy")
        {
            enemys .Add(collider .gameObject );
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag=="Enemy")
        {
            enemys.Remove(collider.gameObject);
        }
    }
}
