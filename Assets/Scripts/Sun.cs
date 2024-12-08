using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Sun : MonoBehaviour
{
    public float moveDuration = 1;
    public int point = 50;
    public void JumpTo(Vector3 targetPos)
    {
        Vector3 centerPos = (transform.position + targetPos) / 2;
        float distance = Vector3.Distance(transform.position, targetPos);

        centerPos.y += (distance / 2);
        // DOPath的参数：路径，时间，曲线类型
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos },
            moveDuration, PathType.CatmullRom).SetEase(Ease.OutQuad);   // 表示先快后慢
    }

    void OnMouseDown()
    {
        SunManager.Instance.AddSun(point);
    }
}
