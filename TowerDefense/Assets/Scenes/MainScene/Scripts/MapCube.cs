using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//UI检测相关

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;

    public GameObject buildEffect;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void BuildTurret(GameObject turretGameObject)
    {
        turretGo = GameObject.Instantiate(turretGameObject, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
    }

    void OnMouseEnter()
    {
        if (turretGo == null && EventSystem.current.IsPointerOverGameObject() == false )
        {
            renderer.material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
