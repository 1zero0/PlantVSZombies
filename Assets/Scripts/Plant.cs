using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlantState
{
    Disable,
    Enable
}
public class Plants : MonoBehaviour
{
    PlantState plantState = PlantState.Disable;


    private void Update()
    {
        switch (plantState)
        {
            case PlantState.Disable:
                DisableUpdate();
                break;
            case PlantState.Enable:
                EnableUpdate();
                break;
            default:
                break;
        }
    }

    void DisableUpdate()
    {
        
    }
    void EnableUpdate()
    {

    }
}
