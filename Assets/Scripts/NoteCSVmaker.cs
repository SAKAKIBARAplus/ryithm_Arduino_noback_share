using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCSVmaker : MonoBehaviour
{
    private AudioSource AudioSource1;       //音楽源
    private float starttime = 0;            //ボタンを押した時間
    private float longtime = 0.0f;

    private CSVWriter CSVWriter1;           //

    private bool isPlaying = false;         //音楽が始まったかどうかを記録
    public GameObject startbutton;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource1 = GameObject.Find("GameMusic").GetComponent<AudioSource>();        // GameMusicのGameObjectを探す。
        CSVWriter1 = GameObject.Find("CSVWriter").GetComponent<CSVWriter>();            //CSVWriterのGameObjectを探す。
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            DetectKeys();       //keyの状態を記録
        }
    }

    public void StartMusic()
    {
        startbutton.SetActive(false);
        AudioSource1.Play();
        starttime = Time.time;          //ボタンが押された時間を記録
        isPlaying = true;               //スタート
    }

    void DetectKeys()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            WriteNoteTiming(GetTiming(),0,0);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            WriteNoteTiming(GetTiming(),1,0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            longtime = GetTiming();
            //WriteNoteTiming(2,0);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if ((Time.time - starttime) - longtime > 1.0f)
            {
                WriteNoteTiming(longtime,2, 1);
                WriteNoteTiming(GetTiming(),2, 2);
            }
            else
            {
                WriteNoteTiming(longtime, 2, 0);
            }
        }
    }

    void WriteNoteTiming(float time,int num,int Lflag)
    {
        //Debug.Log(GetTiming());
        CSVWriter1.WriteCSV(time.ToString() + "," + num.ToString() + "," + Lflag.ToString());
    }

    float GetTiming()
    {
        return Time.time - starttime;       //現在の時間からボタンを押した時間を引いて正確な時間を出す。
    }
}
