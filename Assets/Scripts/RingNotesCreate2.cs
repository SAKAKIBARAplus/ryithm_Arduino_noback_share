using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingNotesCreate2 : MonoBehaviour
{
    public GameObject CSVReaderObject;
    private GameController CSVReader; // = new GameController();

    //private List<List<string>> MAP = new List<List<string>>();
    private float time_L = 0.20f;
    private float time = 0.0f;           //始まってからの時間(ロングノーツの連続時間,最初はtime_Lに合わせる)
    private int Line = 0;           //何番のラインか判定
    private float[] timing;         //タイミングの設定を格納
    private int[] line_number;      //ライン番号の設定を格納
    private int[] long_flag;      //ライン番号の設定を格納

    private float longflag_time = 0;            //ロングノーツの終了時間
    private int long_flag2;                   //ロングノーツの判定フラグ
    private int num_longnote = 0;              //ロングノーツの順番
    private int maxnum_longnote = 0;            //ロングノーツの最大数

    private int selector = 0;       //ラインの番号を格納
    public GameObject notes;        //ノーツ
    public GameObject longnotes;        //ロングノーツ
    private GameObject parent;      //親オブジェクト(性質を受け継ぐ用のオブジェクト)
    private GameObject target;          //向かっていく対象のオブジェクト

    private void Awake()
    {
        parent = gameObject.transform.parent.gameObject;                    //親オブジェクトの位置情報を受け継ぐ
        target = GameObject.Find(parent.name + "/note_judge_point");        //判定ラインはどこ?
        //MAP = CSVReader.LoadCSV("rokoroko");
        selector = int.Parse(parent.name.Replace("ringnote_line", "")) - 1;      //自分のライン番号を確認

        //        CSVReader = CSVReaderObject.GetComponent<GameController>();
        //        //CSVReader.Start();          //CSV情報を読み取る
        //        timing = CSVReader.timing;
        //        line_number = CSVReader.line_number;
    }

    private void Start()
    {
        CSVReader = CSVReaderObject.GetComponent<GameController>();
        timing = CSVReader.timing;
        line_number = CSVReader.line_number;
        long_flag = CSVReader.long_flag;
    }

    private void Update()
    {
        if (Line + 1 <= timing.Length)
        {
//            Debug.Log(Time.deltaTime);
 //           time += Time.deltaTime;
            if (Setting.Audio.time >= timing[Line])
            {
                if (selector == line_number[Line])
                {
                    if(long_flag[Line] == 1)            //ロングノーツのフラグがあれば
                    {
                        float firsttime = timing[Line];
                        long_flag2 = 1;
                        Line++;
                        while (long_flag[Line] == 0 )      //ロングノーツのフラグ終了秒検出
                        {
                            Line++;
                        }
                        longflag_time = timing[Line];
                        long_flag2 = 1;
                        time = time_L + Time.deltaTime;
                        maxnum_longnote = (int)((timing[Line] - firsttime) / time_L);
                        num_longnote = 0;
 //                       Debug.Log(maxnum_longnote);
                    }
                    else
                    {
                        Nodecreate(0,0);              //通常ノーツ
                    }
                }
                Line++;
            }
            if (long_flag2 == 1)                    //ロングノーツの判定があれば
            {
                //            Debug.Log(time);
                if (time >= time_L)
                {
                    if (num_longnote <= maxnum_longnote)
                    {
                        LongNodecreate(maxnum_longnote, num_longnote);                  //ロングノーツ
                    }
                    time = time - time_L;
 //                   Debug.Log(num_longnote);
                    num_longnote++;
                }
                //                        Nodecreate();
                if (Setting.Audio.time >= longflag_time)
                {
                    long_flag2 = 0;
                }
                time += Time.deltaTime;
            }
        }
        //Debug.Log(timing.Length);
        //Debug.Log(Line);
        //Debug.Log(selector);
        //Debug.Log(line_number[Line]);
    }

    private void Nodecreate(int maxnum,int num)
    {
        var note = (GameObject)Instantiate(notes, parent.transform);     //オブジェクトのコピーみたいなやつ;
        note.GetComponent<RingNote2>().target = target;
        note.transform.localPosition = this.transform.localPosition;
        //note.transform.localRotation = Quaternion.Euler(90, 0.0f, 0.0f);
        note.transform.localScale = new Vector3(2.0f, 2.0f, 0.01f);      //親オブジェクトと同じスケールで
        note.GetComponent<RingNote2>().num_longnote = num;
        note.GetComponent<RingNote2>().num_longnote = maxnum;
    }
    private void LongNodecreate(int maxnum, int num)
    {
        var note = (GameObject)Instantiate(longnotes, parent.transform);     //オブジェクトのコピーみたいなやつ;
        note.GetComponent<RingNote2>().target = target;
        note.transform.localPosition = this.transform.localPosition;
        //note.transform.localRotation = Quaternion.Euler(90, 0.0f, 0.0f);
        note.transform.localScale = new Vector3(2.0f, 2.0f, 0.01f);      //親オブジェクトと同じスケールで
        note.GetComponent<RingNote2>().num_longnote = num;
        note.GetComponent<RingNote2>().maxnum_longnote = maxnum;
    }
}
