using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlantState
{
    Disable,
    Enable
}
public class Plant : MonoBehaviour
{
    PlantState plantState = PlantState.Disable;
    public PlantType plantType = PlantType.Sunflower;

    private void Start()
    {
        TransitionToDisable();
    }


    // 判断植物不同状态，去执行不同状态下Update的方法
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
    protected virtual void EnableUpdate()
    {

    }
    // 转换成Disable的方法
    void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false;
    }
    // 转换成Enable的方法
    public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;
    }
    
}
