using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;

    public void BuildTurret(GameObject turretGameObject)
    {
        turretGo = GameObject.Instantiate(turretGameObject, transform.position, Quaternion.identity);
    }
}
