using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Plant currentPlant;
    private void OnMouseDown()
    {
        print("Cell OnMouseDown");
        HandManager.Instance.OnCellCilck(this);
    }

    public bool AddPlant(Plant plant)
    {
        if(currentPlant != null)return false;// �����ǰcell����ֲֲ��򷵻ؿգ���������ֲ
        

        currentPlant = plant;
        currentPlant.transform.position = transform.position;
        plant.TransitionToEnable();
        return true;

    }

    
}