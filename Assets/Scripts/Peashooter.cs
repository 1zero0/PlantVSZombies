using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : Plant
{
    // 这里需要一个射击的频率
    public float shootDuration = 2;
    // 需要一个计时器来控制射击
    private float shootTimer = 0;
    // 用来定位射击的点
    public Transform shootPointTransform;


    // 重写Enable方法来控制豌豆射手进行射击
    protected override void EnableUpdate()
    {
        // 判断时间是否达到射击时间
        shootTimer += Time.deltaTime;
        if(shootTimer > shootDuration)
        {
            Shoot();
            shootTimer = 0;
        }
    }
    // 需要一个射击的方法（这里先让它输出shoot）
    void Shoot()
    {
        print("shoot");
    }
}
