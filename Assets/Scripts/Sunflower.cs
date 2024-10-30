using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : Plant
{
    public float produceDuration = 5;
    private float produceTimer = 0;

    private Animator anim;

    private void Awake() // ��дAwake����
    {
        anim = GetComponent<Animator>();
    }

    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;
        // ͨ����ʱ�����ж��Ƿ��˸����������ʱ�䣬�����������ʱ���ȥ����Animator�е����úõĴ�����Trigger���Ƶ���������Ķ���
        if(produceTimer > produceDuration)
        {
            produceTimer = 0;
            anim.SetTrigger("IsGlowing"); // �ڵ���һ��������ʱ��Ϳ���ȥִ������ķ�������������
        }
    }
    public void ProduceSun()
    {
        // TODO
        print("ProduceSun");
    }
}
