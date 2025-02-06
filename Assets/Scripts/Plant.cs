using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    // 植物的血量
    public int HP = 100;

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

        // 当我们生成植物时，先将Collider禁用掉，当它种植的时候再启用Collider
        GetComponent<Collider2D>().enabled = false;
    }
    // 转换成Enable的方法
    public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;

        // 当我们生成植物时，先将Collider禁用掉，当它种植的时候再启用Collider
        GetComponent<Collider2D>().enabled = true;
    }
    // 新建一个受到伤害的方法
    public void TakeDamage(int damage)
    {
        this.HP -= damage;
        print(damage);
        // 检查一下HP是否<=0；如果为0了，说明植物死亡了。
        if (HP <= 0) 
        {
            // 调用一下Die方法
            Die();
        }
    }
    // 我们这里进行一个死亡的方法处理
    private void Die()
    {
        // 这里没有什么状态，也没有什么特效，我们直接销毁掉这个物品（暂时）
        Destroy(gameObject);
    }


}
