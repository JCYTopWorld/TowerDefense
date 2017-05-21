using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standarTurretData;
    public TurretData selectedTurretData;//表示将要建造的炮台

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                //进行开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
               bool isCollider= Physics.Raycast(ray,out hit , 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    GameObject mapCube = hit.transform.gameObject;
                }
            }
        }
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }

    public void OnStandarSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standarTurretData;
        }
    }
}
