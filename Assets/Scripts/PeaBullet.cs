using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    // ���������ƶ�
    private float speed = 3;

    // �㶹�˺�(�㶹���˺����㶹����������һ���˺����ƣ�
    private int atkValue = 30;
    // ���ڱ�ը��Ч����һ������
    public GameObject peaBulletHitPrefab;
    // ����һ���������������㶹�˺�
    public void SetATKValue(int atkValue)
    {
        this.atkValue = atkValue;
    }
    // �������ǿ����½�һ�����������Ʋ�ͬ�㶹���ٶ�
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    // ������10s�����û�й�������ʬ���Զ�����
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    // �����㶹���˶���������������ǵ��㶹���������˶���
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    // �����뽩ʬ����ײ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ����һ�������жϣ������ж��Ƿ����뽩ʬ������ײ
        if(collision.tag == "Zombie")
        {
            // ����ײ֮���㶹����Ҫ����
            Destroy(this.gameObject);
            // �õ���ʬ�Ľű���Ȼ��Ӧ�ýű��е����˷����������˺����ݹ�ȥ
            collision.GetComponent<Zombie>().TakeDamage(atkValue);
            // ��������Ч����ʵ����
            GameObject go = GameObject.Instantiate(peaBulletHitPrefab, transform.position, Quaternion.identity);
            // ���ٱ�ը��Ч
            Destroy(go, 1);
        }
    }
}
