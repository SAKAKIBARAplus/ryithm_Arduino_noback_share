using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingNote2 : MonoBehaviour
{
    public float movetime = 3.0f;
    private float delta_movetime = 3.0f;
    public GameObject target;
    private new Transform transform;
    private float time = 0.0f;
    private float scale;
    private float scale2;
    private Vector3 v_start;
    private Vector3 v_end;

    public int num_longnote;            //ロングノーツの順番
    public int maxnum_longnote;        //最大ロングノーツ数

    private GameObject parent;      //親オブジェクト(性質を受け継ぐ用のオブジェクト)
    private RingCheckTiming checkTiming;

    public float perfectscale;
    public float goodscale;
    public float badscale;

    private int statusflag = 0;             //1 : bad突入, 2 :good 突入, 3 : perfect突入 

    // Start is called before the first frame update
    void Start()
    {
        //judge = gameObject.transform.parent.gameObject;                    //親オブジェクトの位置情報を受け継ぐ
        checkTiming = target.GetComponent<RingCheckTiming>();        //判定ラインはどこ?

        transform = GetComponent<Transform>();
        scale = this.transform.localScale.x;
        v_start = this.transform.position;
        v_end = target.transform.position;
        delta_movetime = target.transform.localScale.x;         //スケールの取得
        movetime = movetime + (movetime * delta_movetime * delta_movetime);     //movetime秒後にリングの外周に行くような計算
        //transform.position += new Vector3(1.0f,0f,0f);

        perfectscale = checkTiming.perfectscale;
        goodscale = checkTiming.goodscale;
        badscale = checkTiming.badscale;
//        Debug.Log(num_longnote);
    }

    // Update is called once per frame
    void Update()
    {
        var v = time / movetime;
        scale2 = scale - (v * scale);
        transform.localScale = new Vector3(scale2, scale2, 0.01f);
        //transform.position -= new Vector3(0.001f,0f,0f);
//        transform.position = Vector3.Lerp(v_start, v_end, v);
        if (this.gameObject.transform.localScale.x <= 0.08)             //ある程度まで進んだら消す
        {
            Destroy(this.gameObject);
            //checkTiming.Timing["perfect"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
            //checkTiming.Timing["good"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
            checkTiming.Timing["bad"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
            checkTiming.combo = 0;
        }
        //Debug.Log(scale2);

        if (statusflag == 0)
        {
            if (this.gameObject.transform.localScale.x <= badscale)            //大きさがBADエリアと同じになったらリストに追加.Pro Builderとスケールの縮尺が違うらしい。
            {
                checkTiming.Timing["bad"].Add(this.gameObject);
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0.9f, 1f, 0.5f);
                statusflag = 1;
            }
        }
        else if (statusflag == 1)
        {
            if (this.gameObject.transform.localScale.x <= goodscale)            //大きさがGOODエリアと同じになったらリストに追加
            {
                checkTiming.Timing["good"].Add(this.gameObject);
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0.75f, 1f, 0.5f);
                statusflag = 2;
            }
        }
        else if (statusflag == 2)
        {
            if (this.gameObject.transform.localScale.x <= perfectscale + 0.01f)            //大きさがPerfectエリアと同じになったらリストに追加
            {
                checkTiming.Timing["perfect"].Add(this.gameObject);
                this.gameObject.GetComponent<Renderer>().material.color = new Color(0.6f, 1f, 0.5f);
                statusflag = 3;
            }
        }
        else if (statusflag == 3)
        {
            if (this.gameObject.transform.localScale.x <= perfectscale - 0.2f)            //大きさがPerfectエリア外にでたらリストから削除
            {
                checkTiming.Timing["perfect"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
                checkTiming.Timing["good"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
                checkTiming.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);      //赤色にする
                checkTiming.judge = "bad";
                statusflag = 4;
            }
        }

        time += Time.deltaTime;
    }
}
