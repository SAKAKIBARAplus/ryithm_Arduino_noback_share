using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckArduino : MonoBehaviour
{
    public Text GetArduino;
    public GameObject Arduino;
    public float RValue;
    public int BUTTON1;
    public int BUTTON2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RValue = Arduino.GetComponent<StockData>().RValue;
        BUTTON1 = Arduino.GetComponent<StockData>().ButtonP1;
//        if(Arduino.GetComponent<StockData>().Xin > 300)
//        {
//            BUTTON2 = 0;
//        }
//        else
//        {
//            BUTTON2 = 1;
//        }

        GetArduino.text = RValue + "\n" + Arduino.GetComponent<StockData>().RValuebin+ "\n" + BUTTON1 + "\n" + Arduino.GetComponent<StockData>().ButtonP2;
    }
}
