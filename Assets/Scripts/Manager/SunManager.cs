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
    public Vector3 sunPointTextPosition;
    public float produceTime;
    private float produceTimer;
    public GameObject sunPrefab;



    private bool isStartProduce = false;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateSunPointText();
        CalcSunPointTextPositon();
        StartPoduce();
    }

    private void Update()
    {
        if (isStartProduce)
        {
            ProduceSun();
        }
        
    }
    public void StartPoduce()
    {
        isStartProduce=true;
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

    public void AddSun(int point)
    {
        sunPoint += point;
        UpdateSunPointText();
    }

    public Vector3 GetSunPointTextPosition()
    {
        return sunPointTextPosition;
    }

    public void CalcSunPointTextPositon()
    {
        Vector3 positon = Camera.main.ScreenToWorldPoint( sunPointText.transform.position );
        positon.z = 0;
        sunPointTextPosition = positon;
    }

    void ProduceSun()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer > produceTime)
        {
            produceTimer = 0;
            Vector3 position = new Vector3(Random.Range(-5, 6.5f), 6.2f, -1);
            GameObject go = GameObject.Instantiate(sunPrefab, position,Quaternion.identity);

            position.y = Random.Range(-4, 3f);
            go.GetComponent<Sun>().LinearTo( position );
        }
    }
}
