using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Text;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
//    Encoding encoding;

    public float[] timing;
    public int[] line_number;
    public int[] long_flag;
    public Setting setting;
    private string csvname;
    public GameObject noteline;

    public GameObject Totalscore;

    // Start is called before the first frame update

    public void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void Start()
    {
        timing = new float[1024];       //タイミング格納用変数
        line_number = new int[1024];    //番号格納用変数
        long_flag = new int[1024];    //ロングノーツフラグ変数
        LoadCSV();
    }

    public void LoadCSV()
    {
 //       Debug.Log(setting.csvname);
        csvname = setting.csvname;
        TextAsset csv = Resources.Load(csvname) as TextAsset;      //csvファイルを読み取る
 //       Debug.Log(csv.text);
        StringReader reader = new StringReader(csv.text);           //文字型に置き換える

        int i = 0;
        while(reader.Peek() > -1)               //1行づつ読み取る
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
           {
                timing[i] = float.Parse(values[0])-3.0f;
                line_number[i] = int.Parse(values[1]);
                long_flag[i] = int.Parse(values[2]);                    //ロングノーツ用変数
            }
            i++;
        }
        Array.Resize(ref timing, i);
        Array.Resize(ref line_number, i);
        //Debug.Log(timing[0]);

        noteline.SetActive(true);

        Totalscore.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
