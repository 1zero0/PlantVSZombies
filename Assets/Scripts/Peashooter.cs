using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : Plant
{
    // ������Ҫһ�������Ƶ��
    public float shootDuration = 2;
    // ��Ҫһ����ʱ�����������
    private float shootTimer = 0;
    // ������λ����ĵ�
    public Transform shootPointTransform;
    // ������peabullet����һ������
    public PeaBullet peaBulletPrefab;
    // ���������ӵ�������ٶ�
    public float bulletSpeed = 5;


    // ��дEnable�����������㶹���ֽ������
    protected override void EnableUpdate()
    {
        // �ж�ʱ���Ƿ�ﵽ���ʱ��
        shootTimer += Time.deltaTime;
        if(shootTimer > shootDuration)
        {
            Shoot();
            shootTimer = 0;
        }
    }
    // ��Ҫһ������ķ������������������shoot�����ﲻ�������������ķ�����������Ҫ����һ����תֵ��Quaternion.identity��
    void Shoot()
    {
        PeaBullet pb = GameObject.Instantiate(peaBulletPrefab, shootPointTransform.position, Quaternion.identity);
        // ��bulletSpeed���ݹ�ȥ
        pb.SetSpeed(bulletSpeed);
    }
}
