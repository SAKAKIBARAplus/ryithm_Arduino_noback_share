using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTiming : MonoBehaviour
{
    public GameObject Perfect;
    public GameObject Good;
    public GameObject Bad;
    public SoundEffect soundeffect;

    public GameObject Arduino;      //Arduinoの情報を取得
    public int flagbutton = 0;      //ボタン押されてる?
    public int whatkey;             //押したボタンは何?

    public Color color = new Color(1.0f,1.0f,1.0f,1.0f);

    public KeyCode keycode;         //どのボタンを押すのか
    public GameObject status;       //

    public int combo = 0;
    public string judge ="";
    public int score = 0;

    public float perfectscale;
    public float goodscale;
    public float badscale;

    public int perfectcheck;
    public int goodcheck;
    public int badcheck;

    public ShakeObject shakeObject;
    public NoteJudgeEffect noteEffect;


    //public AudioClip perfect_sound;
    //public AudioClip good_sound;
    //public AudioClip bad_sound;

    //AudioSource audioSource;


    private TextMesh status_text;           //コンボ数と判定の表示

    public Dictionary<string,GameObject> TimingSW = new Dictionary<string,GameObject>();
    public Dictionary<string, List<GameObject>> Timing = new Dictionary<string, List<GameObject>>()
    {
        {"perfect",new List<GameObject>() },
        {"good",new List<GameObject>() },
        {"bad",new List<GameObject>() }
    };


    // Start is called before the first frame update
    private void Awake ()
    {
        TimingSW.Add("perfect", Perfect);
        TimingSW.Add("good", Good);
        TimingSW.Add("bad", Bad);
        // status_text = status.GetComponent<Text>();
        status_text = status.GetComponent<TextMesh>();
        status_text.color = color;

        perfectscale = Perfect.transform.localScale.x;
        goodscale = Good.transform.localScale.x;
        badscale = Bad.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        perfectcheck = Timing["perfect"].Count;
        goodcheck = Timing["good"].Count;
        badcheck = Timing["bad"].Count;

        //ボタンの判定
        if (keycode == KeyCode.F)
        {
            if(Arduino.GetComponent<StockData>().ButtonP1 == 1 || Arduino.GetComponent<StockData>().TouchP1 == 1)
            {
                whatkey = 1;
            }
            else
            {
                whatkey = 0;
            }
        }
        else if (keycode == KeyCode.J)
        {
            if (Arduino.GetComponent<StockData>().ButtonP2 == 1 || Arduino.GetComponent<StockData>().TouchP2 == 1)
            {
                whatkey = 1;
            }
            else
            {
                whatkey = 0;
            }
        }
        else
        {
            whatkey = Arduino.GetComponent<StockData>().RValuebin;
        }


        if ((Input.GetKeyDown(keycode)) ||(flagbutton == 0 && whatkey == 1) )
        {
            flagbutton = 1;
            if (Timing["perfect"].Count >= 1)
            {
                Destroy(Timing["perfect"][0]);      //先頭のノーツを削除
                Timing["perfect"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
                Timing["good"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
                Timing["bad"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
                judge = "perfect";
                combo++;
                score = score + 70;
                soundeffect.audioSource.PlayOneShot(soundeffect.perfect_sound);
                color = new Color(1.0f, 0.95f, 0.1f, 1.0f);      //黄色にする

                shakeObject.shakeobject();
                noteEffect.MakeJudgeEffect(1);      //エフェクトを付ける
            }
            else if (Timing["good"].Count >= 1)
            {
                Destroy(Timing["good"][0]);      //先頭のノーツを削除
                Timing["good"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
                Timing["bad"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
                judge = "good";
                score = score + 50;
                combo++;
                soundeffect.audioSource.PlayOneShot(soundeffect.good_sound);
                color = new Color(0.3f, 1.0f, 0.1f, 1.0f);      //緑色にする

                noteEffect.MakeJudgeEffect(2);      //エフェクトを付ける
            }
            else if (Timing["bad"].Count >= 1)
            {
                Destroy(Timing["bad"][0]);      //先頭のノーツを削除
                Timing["bad"].RemoveAt(0);          //Listの先頭行を削除して前詰めする
                judge = "bad";
                combo = 0;
                soundeffect.audioSource.PlayOneShot(soundeffect.bad_sound);
                color = new Color(1.0f, 0.0f, 0.0f, 1.0f);      //赤色にする

                noteEffect.MakeJudgeEffect(3);      //エフェクトを付ける
            }
        }

    if(flagbutton == 1 && whatkey == 0)
    {
        flagbutton = 0;
    }

        status_text.text = judge + "\n" + "combo : " + combo + "\n" + "score : " + score;
        status_text.color = color;
    }
}
