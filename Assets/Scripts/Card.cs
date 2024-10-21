using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum CardState
{
    Cooling,
    WaitingSun,
    Ready
}

public class Card : MonoBehaviour
{
    // 冷却 可以被点击 不可用
    private CardState cardState = CardState.Cooling;

    //要控制植物卡片的状态，就要先获取三种状态
    public GameObject cardLight;
    public GameObject cardGary;
    public Image cardMask;

    [SerializeField]
    private  float cdTime = 2;    // 冷却时间
    private  float cdTimer = 0;   // 计时器，从零开始（可以从零增加到2 ，也可以从最大减少到零）

    [SerializeField]
    private int needSunPoint = 50;

    private void Update()
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
            default:
                break;
        }
    }

    void CoolingUpdate()
    {
        cdTimer += Time.deltaTime;

        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;  // 剩余时间的比例

        if (cdTimer >= cdTime)
        {
            TransitionToWaitingSun();
        }
    }
    void WaitingSunUpdate()
    {
        if (needSunPoint <= SunManager.Instance.SunPoint)
        {
            TransitionToReady();
        }
    }
    void ReadyUpdate()
    {

    }

    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;   // 先改变植物卡片的状态（冷却状态改为灰色状态）

        // 植物状态的启用和禁用
        cardLight.SetActive(false);     // 将植物卡片亮禁用
        cardGary.SetActive(true);       // 植物卡片灰启用
        cardMask.gameObject.SetActive(false);   // 将等待状态禁用
    }
    void TransitionToReady()
    {
        cardState = CardState.Ready;  

        
        cardLight.SetActive(true);     
        cardGary.SetActive(false);       
        cardMask.gameObject.SetActive(false);
    }
}
