using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �½���ʬ����������״̬
enum ZombieState
{
    Move,
    Eat,
    Die
}
public class Zombie : MonoBehaviour
{
    // ����ʬһ��Ĭ��״̬�����ߣ�
    ZombieState zombieState = ZombieState.Move;
    // ��ȡ�������
    private Rigidbody2D rgd;
    // �ƶ����ٶ�
    public float moveSpeed = 2;
    // �õ�animator
    private Animator anim;
    // ��ʬ�Ĺ�����
    public int atkValue = 30;
    // ��ʬ�Ĺ���Ƶ��
    public float atkDuration = 2;
    // ���Կ��ƽ�ʬ�Ĺ����ļ�ʱ
    private float atkTimer = 0;
    // �ڽ�ʬ��ֲ�ﴥ������ʼʱ������Ҫ����һ�µ�ǰ���ڹ�����ֲ��
    private Plant currentEatplant;
    // Ϊ��ʬ����һ��Ѫ��(���Ѫ��)
    public int HP = 100;
    // ��ǰѪ��
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        // ��ȡһ�¸������
        rgd = GetComponent<Rigidbody2D>();
        // ��ȡһ��anim
        anim = GetComponent<Animator>();
        // �ڿ�ʼ��ʱ������Ѫ������һ��
        currentHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        // ����һ��״̬�ж�
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
    // �½�һ��MoveUpdate
    void MoveUpdate()
    {
        // ֻ��������������潩ʬ�Ż��ƶ������ԣ�
        // ���Ƹ����ƶ�(��ǰλ��+�ƶ���������ͨ��MovePosition�ƶ����µ�λ��
        rgd.MovePosition(rgd.position + Vector2.left * moveSpeed * Time.deltaTime);
    }
    void EatUpdate()
    {
        // ������Ҫ���������ֲ���Ѫ���ķ�����������Ҫһ����������
        // �������������һ�������Ŀ���
        atkTimer += Time.deltaTime;
        // ����һ����ȫУ��
        if (atkTimer > atkDuration && currentEatplant != null)
        {
            // ����ֲ�����ϵĵ�Ѫ�����������˺����ݹ�ȥ
            currentEatplant.TakeDamage(atkValue);
            // ����ʱ�����㣬ʹ�ý�ʬ���Լ�������
            atkTimer = 0;
        }
    }
    // �½�һ�����Դ������ķ���(��ʬ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��������������м���Ƿ�Ϊֲ�
        if(collision.tag == "Plant")
        {
            // ���Ľ�ʬ״̬Ϊ��(���������֣�����Ϊtrue��
            anim.SetBool("IsAttacking", true);
            // ��������ÿ��ƹ���ʱ��ķ���
            TransitionToEat();
            // �õ�����������ڹ���ֲ�����ϵ����
            currentEatplant = collision.GetComponent<Plant>();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            // ���Ľ�ʬ״̬Ϊ����(���������֣�����Ϊfalse��
            anim.SetBool("IsAttacking", false);
            // ���Ե�ʱ��Ҫ�ѳԵ�״̬�Ļ��ƶ�
            zombieState = ZombieState.Move;
            // ͬ���������뿪��������ʱ������Ҫ�����ڹ�����ֲ���ƿա�
            currentEatplant = null;
        }
    }
    // ����������Ҫ�ڽ�ʬ���ж�״̬ת��Ϊ��״̬ʱ������ʱ��ת��Ϊ0�������½�һ��������������ʱ�䡣
    void TransitionToEat()
    {
        // ���ﲻ��Ҫ�޸����Ķ���״̬����Ҫ�޸������������״̬
        zombieState = ZombieState.Eat;
        atkTimer = 0;
    }
    // �����½�һ����ʬ���˵�Ѫ�ķ���
    public void TakeDamage(int damage)
    {
        // ����Ҫע�⣬�����ʬ�Ѿ������˾�û���ܻ��˺��ˣ�����Ҫһ���ж���ȷ����ʬ�Ƿ��Ѿ�����
        if (currentHP <= 0) return;
        // ����ʬ���˺�ʼ��Ѫ
        this.currentHP -= damage;
        // ������Ϊ�������õ���Ѫ������0�Żᴥ��������������������������Ѫ������0ʱֱ��Ϊ����Ѫ����ֵΪ-1
        if (currentHP <= 0)
        {
            // ȷ���ᴥ����������
            currentHP = -1;
            Dead();
        }
        // ��֪����ǰѪ���İٷֱ�(������֮һ��Ϊfloat��
        float hpPercent = currentHP*1f / HP;
        // Ȼ������ֵ
        anim.SetFloat("HPPercent", hpPercent);
    }
    // �����ķ���
    private void Dead()
    {
        // ����Ҫ����ʬ��״̬����Ϊdie
        zombieState = ZombieState.Die;
        // ���õ���ʬ���ϵ���ײ����collider��
        GetComponent<Collider2D>().enabled = false;

        // ��һ��ʱ���ʬ��Ҫ��������
        Destroy(this.gameObject, 2);
    }
}
