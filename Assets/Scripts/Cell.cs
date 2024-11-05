using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Plant currentPlant;
    private void OnMouseDown()
    {

        HandManager.Instance.OnCellCilck(this);
    }

    public bool AddPlant(Plant plant)
    {
        if(currentPlant != null)return false;// 如果当前cell有种植植物，则返回空，即不可种植
        

        currentPlant = plant;
        currentPlant.transform.position = transform.position;
        plant.TransitionToEnable();
        return true;

    }

    
}
