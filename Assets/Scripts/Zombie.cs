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

    // Start is called before the first frame update
    void Start()
    {
        // ��ȡһ�¸������
        rgd = GetComponent<Rigidbody2D>();
        // ��ȡһ��anim
        anim = GetComponent<Animator>();
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

    }
    // �½�һ�����Դ������ķ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��������������м���Ƿ�Ϊֲ�
        if(collision.tag == "Plant")
        {
            // ���Ľ�ʬ״̬Ϊ��(���������֣�����Ϊtrue��
            anim.SetBool("IsAttacking", true);
            // ���ﲻ��Ҫ�޸����Ķ���״̬����Ҫ�޸������������״̬
            zombieState = ZombieState.Eat;
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
        }
    }
}
