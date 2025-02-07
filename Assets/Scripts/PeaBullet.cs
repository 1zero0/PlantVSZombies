using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    // 可以向右移动
    private float speed = 3;

    // 豌豆伤害(豌豆的伤害用豌豆射手来进行一个伤害控制）
    private int atkValue = 30;
    // 对于爆炸特效进行一个持有
    public GameObject peaBulletHitPrefab;
    // 设置一个方法用来更改豌豆伤害
    public void SetATKValue(int atkValue)
    {
        this.atkValue = atkValue;
    }
    // 这里我们可以新建一个方法来控制不同豌豆的速度
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    // 在生成10s后如果没有攻击到僵尸就自动销毁
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    // 控制豌豆的运动，正常情况下我们的豌豆都是向右运动的
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    // 进行与僵尸的碰撞检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 先做一个条件判断，用以判断是否是与僵尸进行碰撞
        if(collision.tag == "Zombie")
        {
            // 在碰撞之后，豌豆自身要销毁
            Destroy(this.gameObject);
            // 得到僵尸的脚本，然后应用脚本中的受伤方法，并将伤害传递过去
            collision.GetComponent<Zombie>().TakeDamage(atkValue);
            // 将爆裂特效进行实例化
            GameObject go = GameObject.Instantiate(peaBulletHitPrefab, transform.position, Quaternion.identity);
            // 销毁爆炸特效
            Destroy(go, 1);
        }
    }
}
