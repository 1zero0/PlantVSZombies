using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    // ���������ƶ�
    private float speed = 3;
    // �������ǿ����½�һ�����������Ʋ�ͬ�㶹���ٶ�
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    
    // �����㶹���˶���������������ǵ��㶹���������˶���
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
