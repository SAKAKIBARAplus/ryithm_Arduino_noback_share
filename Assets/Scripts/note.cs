using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour
{
    public float movetime;
    public GameObject target;
    public GameObject standard;
    public GameObject lostpoint;
    private float time = 0.0f;
    private new Transform transform;
    // Start is called before the first frame update
    private Vector3 v_start;
    private Vector3 v_end;

    private float dx = 0.0f;                //最初と最後の距離
    private float dsita = 0.0f;             //判定基準位置の時間合わせよう
    private float r = 0.0f;                 //円の半径
    private float startsita = 0.0f;         //初期スタート位置

    private float ScaleX;
    private float ScaleFirstX;
    private float ScaleZ;
    private float ScaleFirstZ;

    void Start()
    {
        transform = GetComponent<Transform>();
        v_end = target.transform.position;
        v_start = standard.transform.position;

        dx = v_start.x - v_end.x;
        startsita = 75;

        ScaleX = this.transform.localScale.x;
        ScaleFirstX = ScaleX / 2;
        ScaleZ = this.transform.localScale.z;
        ScaleFirstZ = ScaleZ / 2;
        this.transform.localScale = new Vector3(ScaleFirstX, 1, ScaleFirstZ);
    }

    // Update is called once per frame
    void Update()
    {
        var v = time / movetime;

        r = dx;

        dsita = (185 - startsita) * v;
        Vector3 pos = transform.position;
        pos.x = v_start.x + r * Mathf.Cos((dsita + startsita) * (Mathf.PI / 180));      //xの位置確認
        pos.y = v_start.y + (r * Mathf.Sin((dsita + startsita) * (Mathf.PI / 180)));    //yの位置確認

        transform.position = pos;               //位置を変更

        if (v <= 1)
        {
            ScaleX = ScaleFirstX + ScaleFirstX * v;
            ScaleZ = ScaleFirstZ + ScaleFirstZ * v;
        }
        this.transform.localScale = new Vector3(ScaleX, 1, ScaleZ);
        //this.transform.localScale = 

        time += Time.deltaTime;
        if(this.transform.position == v_end)
        {
            //Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (target == collision.gameObject)
        {
            //v_start = this.transform.position;
            //target = lostpoint;
            //v_end = target.transform.position;
            //time = 0.0f;
            //endflag = 1;
            //Debug.Log("aaaaa");
        }
        if (lostpoint == collision.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
