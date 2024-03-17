using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteJudgeEffect : MonoBehaviour
{
    public GameObject perfecteffect;        //perfect時のeffect
    public GameObject goodeffect;        //good時のeffect
    public GameObject badeffect;        //bad時のeffect

//    private void Awake()
//    {
//        parent = gameObject.transform.parent.gameObject;                    //親オブジェクトの位置情報を受け継ぐ
//    }

        // Start is called before the first frame update
        void Start()
    {

    }

    public void MakeJudgeEffect(int effect)     //エフェクトを付ける
    {
        if (effect == 1)        //Perfectの時
        {
            GameObject NoteEffect = perfecteffect;
            Instantiate(NoteEffect,this.transform);
            NoteEffect.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
        }
        else if (effect == 2)       //Goodの時
        {
            GameObject NoteEffect = goodeffect;
            Instantiate(NoteEffect, this.transform);
            NoteEffect.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (effect == 3)       //Badの時
        {
            GameObject NoteEffect = badeffect;
            Instantiate(NoteEffect, this.transform);
            NoteEffect.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
