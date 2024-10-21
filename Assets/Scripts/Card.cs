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
    // ��ȴ ���Ա���� ������
    private CardState cardState = CardState.Cooling;

    //Ҫ����ֲ�￨Ƭ��״̬����Ҫ�Ȼ�ȡ����״̬
    public GameObject cardLight;
    public GameObject cardGary;
    public Image cardMask;

    [SerializeField]
    private  float cdTime = 2;    // ��ȴʱ��
    private  float cdTimer = 0;   // ��ʱ�������㿪ʼ�����Դ������ӵ�2 ��Ҳ���Դ������ٵ��㣩

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

        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;  // ʣ��ʱ��ı���

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
        cardState = CardState.WaitingSun;   // �ȸı�ֲ�￨Ƭ��״̬����ȴ״̬��Ϊ��ɫ״̬��

        // ֲ��״̬�����úͽ���
        cardLight.SetActive(false);     // ��ֲ�￨Ƭ������
        cardGary.SetActive(true);       // ֲ�￨Ƭ������
        cardMask.gameObject.SetActive(false);   // ���ȴ�״̬����
    }
    void TransitionToReady()
    {
        cardState = CardState.Ready;  

        
        cardLight.SetActive(true);     
        cardGary.SetActive(false);       
        cardMask.gameObject.SetActive(false);
    }
}
