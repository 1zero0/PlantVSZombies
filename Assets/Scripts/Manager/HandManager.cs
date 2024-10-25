using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance { get; private set; }

    public List<Plant> plantPrefabsList;

    private Plant currentPlant;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        FollowCursor();
    }

    public void AddPlant(PlantType plantType)
    {
        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null) 
        {
            print("Ҫ��ֲ��ֲ�ﲻ����");return;
        }
        currentPlant = GameObject.Instantiate(plantPrefab);
    }

    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach (Plant plant in plantPrefabsList) 
        { 
            if(plant.plantType == plantType)
            {
                return plant;
            }
        }
        return null;
    }

    void FollowCursor()
    {
        if (currentPlant == null) return;   // ���ж�����Ƿ�����ȡֲ�￨Ƭ

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // ����Ļ����ת��Ϊ��������
        mouseWorldPosition.z = 0;
        currentPlant.transform.position = mouseWorldPosition; // ��������괫�ݸ�ֲ��

    }
}
