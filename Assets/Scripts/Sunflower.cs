using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : Plant
{
    public float produceDuration = 5;
    private float produceTimer = 0;

    private Animator anim;

    public GameObject sunPrefab;

    public float jumpMinDistance = 0.3f;
    public float jumpMaxDistance = 2;

    private void Awake() // 重写Awake方法
    {
        anim = GetComponent<Animator>();
    }

    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;
        // 通过计时器先判断是否到了该生产阳光的时间，如果到了生产时间就去播放Animator中的设置好的触发器Trigger控制的生产阳光的动画
        if(produceTimer > produceDuration)
        {
            produceTimer = 0;
            anim.SetTrigger("IsGlowing"); // 在到达一个高亮的时候就可以去执行下面的方法来生产阳光
        }
    }
    public void ProduceSun()
    {
        // TODO
        GameObject go = GameObject.Instantiate(sunPrefab, transform.position, Quaternion.identity);

        float distance  = Random.Range(jumpMinDistance, jumpMaxDistance);
        distance = Random.Range(0, 2) < 1 ? -distance : distance;
        Vector3 position = transform.position;
        position.x += distance;

        go.GetComponent<Sun>().JumpTo(position);
    }
}
