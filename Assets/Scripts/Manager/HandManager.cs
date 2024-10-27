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

    public bool AddPlant(PlantType plantType)
    {
        if(currentPlant != null) return false;

        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null) 
        {
            print("要种植的植物不存在");return false;
        }
        currentPlant = GameObject.Instantiate(plantPrefab);
        return true;
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
        if (currentPlant == null) return;   // 先判断鼠标是否有拿取植物卡片

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // 将屏幕坐标转换为世界坐标
        mouseWorldPosition.z = 0;
        currentPlant.transform.position = mouseWorldPosition; // 将鼠标坐标传递给植物

    }

    public void OnCellCilck(Cell cell)
    {
        if(currentPlant == null) return;
        // 将植物放置到cell的位置

        bool isSuccess = cell.AddPlant(currentPlant);

        if (isSuccess) // 如果种植成功，将鼠标植物设置为空，表示可以继续种植下一个植物
        {
            currentPlant = null;    
        }

    }
}
