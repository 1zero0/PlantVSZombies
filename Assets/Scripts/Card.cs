using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
    void WaitingSunUpdate()
    {

    }
    void ReadyUpdate()
    {

    }
}
