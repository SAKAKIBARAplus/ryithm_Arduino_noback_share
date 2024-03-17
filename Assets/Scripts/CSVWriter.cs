using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    public GameObject time;
    

    // Start is called before the first frame update
    void Start()
    {
        //WriteCSV ("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;      //書き込む文字の操作をする関数
        FileInfo fileInfo;      //アドレス
        fileInfo = new FileInfo(Application.dataPath + "/Scripts/Resources/supanakatate.csv");
        streamWriter = fileInfo.AppendText();   //新しいテキストファイルに書き込みを行うstreamwriterを取得
        streamWriter.WriteLine(txt);        //txtの値をストリームライターに書き込む
        streamWriter.Flush();               //ストリームライターの値を対象に書き込む
        streamWriter.Close();
    }

    public void UpdateCSV()
    {

    }
}
