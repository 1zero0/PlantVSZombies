using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance { get; private set; }
    
    [SerializeField]
    private int sunPoint;
    public int SunPoint
    {
        get { return sunPoint; }
    }
    public TextMeshProUGUI sunPointText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateSunPointText();
    }

    private void UpdateSunPointText()
    {
        sunPointText.text = sunPoint.ToString();
    }

    public void SubSun(int point) 
    {
        sunPoint -= point;
        UpdateSunPointText();
    }
}
