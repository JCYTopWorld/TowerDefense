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
    public int money = 1000;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                //进行开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.transform.GetComponent<MapCube>();
                    if (mapCube.turretGo == null)
                    {
                        //可以创建
                        if (money > selectedTurretData.cost)
                        {
                            money -= selectedTurretData.cost;
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                        }
                        else
                        {
                            //钱币不够
                        }
                    }
                    else
                    {
                        //TODO升级处理

                    }
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
