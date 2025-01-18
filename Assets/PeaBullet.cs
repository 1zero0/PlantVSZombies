using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    // 可以向右移动
    private float speed = 3;
    // 这里我们可以新建一个方法来控制不同豌豆的速度
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    
    // 控制豌豆的运动，正常情况下我们的豌豆都是向右运动的
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
