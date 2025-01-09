using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Sun : MonoBehaviour
{
    public float moveDuration = 1;
    public int point = 50;


    public void LinearTo(Vector3 targetPos)
    {
        transform.DOMove(targetPos, moveDuration);
    }
    public void JumpTo(Vector3 targetPos)
    {
        targetPos.z = -1;
        Vector3 centerPos = (transform.position + targetPos) / 2;
        float distance = Vector3.Distance(transform.position, targetPos);

        centerPos.y += (distance / 2);
        // DOPath的参数：路径，时间，曲线类型
        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos },
            moveDuration, PathType.CatmullRom).SetEase(Ease.OutQuad);   // 表示先快后慢
    }

    void OnMouseDown()
    {
        


        transform.DOMove(SunManager.Instance.GetSunPointTextPosition(), moveDuration)
            .SetEase(Ease.OutQuad) // 链式编程
            .OnComplete(
            () =>
            {
                Destroy(this.gameObject); // 销毁自身得函数
                SunManager.Instance.AddSun(point);
            }
            );
    }
}
