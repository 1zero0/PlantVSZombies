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
    // ֲ���Ѫ��
    public int HP = 100;

    private void Start()
    {
        TransitionToDisable();
    }


    // �ж�ֲ�ﲻͬ״̬��ȥִ�в�ͬ״̬��Update�ķ���
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
    // ת����Disable�ķ���
    void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false;

        // ����������ֲ��ʱ���Ƚ�Collider���õ���������ֲ��ʱ��������Collider
        GetComponent<Collider2D>().enabled = false;
    }
    // ת����Enable�ķ���
    public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true;

        // ����������ֲ��ʱ���Ƚ�Collider���õ���������ֲ��ʱ��������Collider
        GetComponent<Collider2D>().enabled = true;
    }
    // �½�һ���ܵ��˺��ķ���
    public void TakeDamage(int damage)
    {
        this.HP -= damage;
        print(damage);
        // ���һ��HP�Ƿ�<=0�����Ϊ0�ˣ�˵��ֲ�������ˡ�
        if (HP <= 0) 
        {
            // ����һ��Die����
            Die();
        }
    }
    // �����������һ�������ķ�������
    private void Die()
    {
        // ����û��ʲô״̬��Ҳû��ʲô��Ч������ֱ�����ٵ������Ʒ����ʱ��
        Destroy(gameObject);
    }


}
