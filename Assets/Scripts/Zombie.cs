using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 新建僵尸的三种物理状态
enum ZombieState
{
    Move,
    Eat,
    Die
}
public class Zombie : MonoBehaviour
{
    // 给僵尸一个默认状态（行走）
    ZombieState zombieState = ZombieState.Move;
    // 获取刚体组件
    private Rigidbody2D rgd;
    // 移动的速度
    public float moveSpeed = 2;
    // 得到animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // 获取一下刚体组件
        rgd = GetComponent<Rigidbody2D>();
        // 获取一下anim
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 进行一个状态判断
        switch (zombieState)
        {
            case ZombieState.Move:
                MoveUpdate();
                break;
            case ZombieState.Eat:
                break;
            case ZombieState.Die:
                break;
            default:
                break;
        }
        
    }
    // 新建一个MoveUpdate
    void MoveUpdate()
    {
        // 只有在这个方法里面僵尸才会移动，所以：
        // 控制刚体移动(当前位置+移动的向量）通过MovePosition移动到新的位置
        rgd.MovePosition(rgd.position + Vector2.left * moveSpeed * Time.deltaTime);
    }
    void EatUpdate()
    {

    }
    // 新建一个用以触发检测的方法
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 对遇到的物体进行检测是否为植物。
        if(collision.tag == "Plant")
        {
            // 更改僵尸状态为吃(触发器名字，设置为true）
            anim.SetBool("IsAttacking", true);
            // 这里不禁要修改它的动画状态，还要修改他自身的物理状态
            zombieState = ZombieState.Eat;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            // 更改僵尸状态为不吃(触发器名字，设置为false）
            anim.SetBool("IsAttacking", false);
            // 不吃的时候要把吃的状态改回移动
            zombieState = ZombieState.Move;
        }
    }
}
