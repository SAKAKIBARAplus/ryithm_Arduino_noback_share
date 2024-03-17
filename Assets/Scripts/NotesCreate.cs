using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesCreate : MonoBehaviour
{
    public GameObject CSVReaderObject;
    private GameController CSVReader;// = new GameController();
    //private List<List<string>> MAP = new List<List<string>>();
    public float time=0;           //始まってからの時間
    private int Line = 0;           //何番のラインか判定
    private float[] timing;         //タイミングの設定を格納
    private int[] line_number;      //ライン番号の設定を格納
    private int selector = 0;       //ラインの番号を格納
    public GameObject notes;        //ノーツ
    private GameObject parent;      //親オブジェクト(性質を受け継ぐ用のオブジェクト)
    private GameObject target;          //向かっていく対象のオブジェクト
    private GameObject lostPosition;        //消失するポイントのオブジェクト
    private GameObject standardPosition;        //基準ポイントのオブジェクト

    //public GameObject setting;
    //public AudioSource audiosouce;

    private void Awake()
    {
        parent = gameObject.transform.parent.gameObject;                    //親オブジェクトの位置情報を受け継ぐ
        target = GameObject.Find(parent.name + "/note_judge_point");        //判定ラインはどこ?
        lostPosition = GameObject.Find(parent.name + "/note_lost_point");   //消失点はどこ?
        standardPosition = GameObject.Find(parent.name + "/StandardPoint");   //基準点はどこ?
        //MAP = CSVReader.LoadCSV("rokoroko");
        selector = int.Parse(parent.name.Replace("note_line","")) - 1;      //自分のライン番号を確認

//        CSVReader = CSVReaderObject.GetComponent<GameController>();
//        //CSVReader.Start();          //CSV情報を読み取る
//        timing = CSVReader.timing;  
//        line_number = CSVReader.line_number;
//        Debug.Log(timing.Length);
    }

    private void Start()
    {
        CSVReader = CSVReaderObject.GetComponent<GameController>();
        timing = CSVReader.timing;
        line_number = CSVReader.line_number;
    }

    private void Update()
    {
        if(Line+1 <= timing.Length )
        {
            time += Time.deltaTime;
            //Debug.Log(Setting.Audio);
            if (Setting.Audio.time >= timing[Line])
            {
                if (selector == line_number[Line])
                {
                    //Debug.Log(line_number[Line]);
                    Nodecreate();
                    // Debug.Log(line_number[Line]);
                }
                Line++;
            }
        }
        //Debug.Log(timing.Length);
        //Debug.Log(Line);
        //Debug.Log(selector);
        //Debug.Log(line_number[Line]);
    }

    private void Nodecreate()
    {
        var note = (GameObject)Instantiate(notes,parent.transform);     //オブジェクトのコピーみたいなやつ
        note.GetComponent<note>().target = target;
        note.GetComponent<note>().lostpoint = lostPosition;
        note.GetComponent<note>().standard = standardPosition;
        note.transform.localPosition = this.transform.localPosition;
        //note.transform.localPosition = standardPosition.transform.localPosition;
        note.transform.localRotation = Quaternion.Euler(90, 0.0f, 0.0f);
        note.transform.localScale = target.transform.localScale;//new Vector3(0.1f, 1f, 0.625f);      //親オブジェクトと同じスケールで
    }
}
