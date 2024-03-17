using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StockData : MonoBehaviour
{
    public SerialHandller serialHandler;
    public Text text;
    public Text BPM1;
    public Text BPM2;
    public string[] datas;
    public float RValue;        //手を繋いだ時の抵抗の割合
    public int RValuebin;
    public float Xin;           //スティック入力X
    public float Yin;           //スティック入力Y
    public int ButtonP1;          //
    public int TouchP1;
    public int ButtonP2;         //
    public int TouchP2;
    public float BPM_P1;        //BPM プレイヤー1
    public float BPM_P2;

    [SerializeField]
 //   private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }

    // Update is called once per frame
    void Update()
    {
        if (BPM_P2 > 90)
        {
            //gameManager.duration = 1;
        }
        else if (BPM_P2 < 90)
        {
            //gameManager.duration = 2;
        }
    }
    void OnDataReceived(string message)
    {
        //       RValue = float.Parse(message);
        datas = message.Split(',');

        //               Debug.LogWarning("Handshake");
        try
        {
            RValue = float.Parse(datas[0]) * 4;
            ButtonP1 = int.Parse(datas[1]);
            TouchP1 = int.Parse(datas[2]);
            ButtonP2 = int.Parse(datas[3]);
            TouchP2 = int.Parse(datas[4]);
            //Xin = float.Parse(datas[1]);
            //Yin = float.Parse(datas[2]);
            //Button = int.Parse(datas[7]);
            //BPM_P1 = float.Parse(datas[4]);
            //BPM_P2 = float.Parse(datas[6]);
            //           Debug.LogWarning("RValue1 : " + RValue);
            //           RValue = RValue * 4;
            //           Debug.LogWarning("RValue2 : "+RValue);
            if (RValue/1024 >= 0.3)
            {
                RValuebin = 1;
            }else if(RValue / 1024 <= 0.2)
            {
                RValuebin = 0;
            }
            else
            {
 //               RValuebin = 3;
            }
            text.text = "ResisterValue : " + RValue.ToString() + "\n" + "Button1 : " + datas[1] + "\n" + "Touch1 : " + datas[2] + "\n"; // シリアルの値をテキストに表示
            BPM1.text = datas[4];
            BPM2.text = datas[6];
        }
        catch (System.Exception e)
        {
 //           Debug.LogWarning(e.Message);
        }
        //        Debug.LogWarning("RValue2 : " + RValue);
        //              Debug.LogWarning("Rvalue : "+ RValue);
    }

    //   public static float getRvalue()
    //   {
    //       return Rvalue2;
    //   }
}
