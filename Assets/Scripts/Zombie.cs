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
    // 僵尸的攻击力
    public int atkValue = 30;
    // 僵尸的攻击频率
    public float atkDuration = 2;
    // 用以控制僵尸的攻击的计时
    private float atkTimer = 0;
    // 在僵尸与植物触发器开始时我们需要保存一下当前正在攻击的植物
    private Plant currentEatplant;
    // 为僵尸增加一个血量(最大血量)
    public int HP = 100;
    // 当前血量
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        // 获取一下刚体组件
        rgd = GetComponent<Rigidbody2D>();
        // 获取一下anim
        anim = GetComponent<Animator>();
        // 在开始的时候和最大血量保持一致
        currentHP = HP;
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
                EatUpdate();
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
        // 我们需要在这里调用植物掉血量的方法，这里需要一个攻击力。
        // 我们在这里进行一个攻击的控制
        atkTimer += Time.deltaTime;
        // 加上一个安全校验
        if (atkTimer > atkDuration && currentEatplant != null)
        {
            // 调用植物身上的掉血方法，并将伤害传递过去
            currentEatplant.TakeDamage(atkValue);
            // 将计时器归零，使得僵尸可以继续攻击
            atkTimer = 0;
        }
    }
    // 新建一个用以触发检测的方法(僵尸攻击）
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 对遇到的物体进行检测是否为植物。
        if(collision.tag == "Plant")
        {
            // 更改僵尸状态为吃(触发器名字，设置为true）
            anim.SetBool("IsAttacking", true);
            // 在这里调用控制攻击时间的方法
            TransitionToEat();
            // 得到我们这个正在攻击植物身上的组件
            currentEatplant = collision.GetComponent<Plant>();
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
            // 同样当我们离开触发器的时候我们要将正在攻击的植物制空。
            currentEatplant = null;
        }
    }
    // 这里我们需要在僵尸从行动状态转换为吃状态时，攻击时间转换为0，所以新建一个方法用来控制时间。
    void TransitionToEat()
    {
        // 这里不禁要修改它的动画状态，还要修改他自身的物理状态
        zombieState = ZombieState.Eat;
        atkTimer = 0;
    }
    // 这里新建一个僵尸受伤掉血的方法
    public void TakeDamage(int damage)
    {
        // 这里要注意，如果僵尸已经死亡了就没有受击伤害了，所以要一个判断来确定僵尸是否已经死亡
        if (currentHP <= 0) return;
        // 当僵尸受伤后开始减血
        this.currentHP -= damage;
        // 这里因为我们设置的是血量低于0才会触发死亡动画，所以我们这里在血量低于0时直接为现在血量赋值为-1
        if (currentHP <= 0)
        {
            // 确保会触发死亡动画
            currentHP = -1;
            Dead();
        }
        // 先知道当前血量的百分比(将其中之一改为float）
        float hpPercent = currentHP*1f / HP;
        // 然后设置值
        anim.SetFloat("HPPercent", hpPercent);
    }
    // 死亡的方法
    private void Dead()
    {
        // 首先要将僵尸的状态设置为die
        zombieState = ZombieState.Die;
        // 禁用掉僵尸身上的碰撞器（collider）
        GetComponent<Collider2D>().enabled = false;

        // 隔一段时间后僵尸需要销毁自身
        Destroy(this.gameObject, 2);
    }
}
