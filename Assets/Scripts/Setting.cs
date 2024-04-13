using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class Setting : MonoBehaviour
{
    public GameObject Arduino;

    public int sss = 0;

    public string csvname;

    public AudioSource BGM;

    public AudioSource rokoroko1;
    public AudioSource rokoroko2;
    public AudioSource rokoroko3;
    public AudioSource rokoroko4;
    public AudioSource kandaigakka;
    public AudioSource kandaisyoyo;
    public AudioSource utanakioka;
    public AudioSource amenohikukan;
    public AudioSource nutscracker;
    public AudioSource haisense;
    public AudioSource shining_star;
    public AudioSource supanakatate;
    public AudioSource selectM;
    public AudioClip selectmusic;
    public AudioClip fixmusic;

    public static AudioSource Audio;
    public int select = 0;
    static int buttoncondition = 0;

    private Color defaultcolor = new Color(1f, 1f, 0.9f);
    private Color modifycolor = new Color(1f, 1f, 0.39f);

    private Color defaultcolor_easy = new Color(0.8f, 1f, 0.8f);
    private Color modifycolor_easy = new Color(0.8f, 1f, 0.4f);

    private Color defaultcolor1;
    private Color modifycolor1;
    private Color defaultcolor1_easy;
    private Color modifycolor1_easy;

    public int touchflag = 0;

    private int EASYMODE = 0;
    // テキストを表示するゲームオブジェクトへの参照
    public GameObject textObject;
    // テキストコンポーネントへの参照
    private Text textComponent;
    // 変更するテキスト
    public string newText = "";

    public GameObject song0;
    public GameObject song1;
    public GameObject song2;
    public GameObject song3;
    public GameObject song4;
    public GameObject song5;
    public GameObject song6;
    public GameObject song7;
    public GameObject ModeSelect;

    public GameObject background;
    public GameObject blackback;
    public static int backgroundflag;

    public GameObject CSV;
    //   public GameObject Totalscore;

    public Text RemainTime;

    int selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        selectM = GetComponent<AudioSource>();

        if(backgroundflag == 1)
        {
            blackback.SetActive(false);
            background.SetActive(true);
        }
        else if (backgroundflag == 0)
        {
            blackback.SetActive(true);
            background.SetActive(false);
        }
        //while(Time.time < 1)
        //{
        //}
        defaultcolor1 = defaultcolor;
        modifycolor1 = modifycolor;
        defaultcolor1_easy = defaultcolor_easy;
        modifycolor1_easy = modifycolor_easy;

        // テキストコンポーネントを取得
        textComponent = textObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == 0)
        {
            selectsong();
            selectbackground();

            if (Input.GetKeyDown(KeyCode.Space) || Arduino.GetComponent<StockData>().RValuebin == 1)
            {
                if (touchflag == 0)
                {
                    setinformation();
                    if (EASYMODE == 0)
                    {
                        defaultcolor1 = defaultcolor;
                        modifycolor1 = modifycolor;
                        defaultcolor1_easy = defaultcolor_easy;
                        modifycolor1_easy = modifycolor_easy;
                    }
                    else
                    {
                        defaultcolor1 = defaultcolor_easy;
                        modifycolor1 = modifycolor_easy;
                        defaultcolor1_easy = defaultcolor;
                        modifycolor1_easy = modifycolor;
                    }
                }

                ChangeTheText();
                
                song0.GetComponent<Image>().color = defaultcolor1;
                song1.GetComponent<Image>().color = defaultcolor1;
                song2.GetComponent<Image>().color = defaultcolor1;
                song3.GetComponent<Image>().color = defaultcolor1;
                song4.GetComponent<Image>().color = defaultcolor1;
                song5.GetComponent<Image>().color = defaultcolor1;
                song6.GetComponent<Image>().color = defaultcolor1;
                song7.GetComponent<Image>().color = defaultcolor1;
                ModeSelect.GetComponent<Image>().color = modifycolor1_easy;

                touchflag = touchflag + 1;

            }
            else
            {
                touchflag = 0;
            }

            if (select == 0)
            {
                song0.GetComponent<Image>().color = modifycolor1;      //色を変える
                song1.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                ModeSelect.GetComponent<Image>().color = defaultcolor1_easy;      //色を戻す
            }
            if (select == 1)
            {
                song0.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                song1.GetComponent<Image>().color = modifycolor1;      //色を変える
                song2.GetComponent<Image>().color = defaultcolor1;      //色を戻す
            }
            if (select == 2)
            {
                song1.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                song2.GetComponent<Image>().color = modifycolor1;      //色を変える
                song3.GetComponent<Image>().color = defaultcolor1;      //色を戻す
            }
            if (select == 3)
            {
                song2.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                song3.GetComponent<Image>().color = modifycolor1;      //色を変える
                song4.GetComponent<Image>().color = defaultcolor1;      //色を戻す
            }
            if (select == 4)
            {
                song3.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                song4.GetComponent<Image>().color = modifycolor1;      //色を変える
                song5.GetComponent<Image>().color = defaultcolor1;      //色を戻す
            }
            if (select == 5)
            {
                song4.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                song5.GetComponent<Image>().color = modifycolor1;      //色を変える
                song6.GetComponent<Image>().color = defaultcolor1;      //色を戻す
            }
            if (select == 6)
            {
                song5.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                song6.GetComponent<Image>().color = modifycolor1;      //色を変える
                song7.GetComponent<Image>().color = defaultcolor1;      //色を戻す
            }
            if (select == 7)
            {
                song6.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                song7.GetComponent<Image>().color = modifycolor1;      //色を変える
                ModeSelect.GetComponent<Image>().color = defaultcolor1_easy;      //色を戻す
            }
            if (select == 8)
            {
                song0.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                song7.GetComponent<Image>().color = defaultcolor1;      //色を戻す
                ModeSelect.GetComponent<Image>().color = modifycolor1_easy;      //色を変える
            }
        }

        if (selected == 1)
        {
 //           Debug.Log(Audio.time);
            RemainTime.text = string.Format("Time : {0:000}",Audio.clip.length - Audio.time);
            if (Audio.isPlaying == false)
            {
                //Totalscore.SetActive(true);
                SceneManager.LoadScene("Result");
            }
        }

    }

    void setinformation()
    {
        selectM.PlayOneShot(fixmusic);
        if (select == 0)
        {
            csvname = song0.name;
            Audio = supanakatate;            
        }

        if (select == 1)
        {
            csvname = song1.name;
            Audio = shining_star;
        }

        if (select == 2)
        {
            csvname = song2.name;
            Audio = kandaigakka;
        }

        if (select == 3)
        {
            csvname = song3.name;
            Audio = haisense;
        }
        if (select == 4)
        {
            csvname = song4.name;
            Audio = rokoroko3;
        }

        if (select == 5)
        {
            csvname = song5.name;
            Audio = rokoroko4;
        }

        if (select == 6)
        {
            csvname = song6.name;
            Audio = nutscracker;
        }
        if (select == 7)
        {
            csvname = song7.name;
            Audio = amenohikukan;
        }
        if (select == 8)
        {
            if (EASYMODE == 0)
            {
                EASYMODE = 1;
            }
            else
            {
                EASYMODE = 0;
            }
        }
        else
        {
            if(EASYMODE == 1)
            {
                csvname = csvname + "_easy";
            }
            Destroy(GameObject.Find("MusicSelect"));                //曲選択画面削除     
            selected = 1;                                           //選択済みフラグ ON 
            Audio.Play();
            CSV.SetActive(true);

            BGM.Stop();
        }

    }

    void selectsong()
    {
        if (selected == 0)
        {
            if (buttoncondition == 0)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Arduino.GetComponent<StockData>().ButtonP1 == 1 || Arduino.GetComponent<StockData>().TouchP1 == 1)
                {
                    buttoncondition = 1;
                    selectM.PlayOneShot(selectmusic);
                    select++;           //セレクト番号を1増やす
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Arduino.GetComponent<StockData>().ButtonP2 == 1 || Arduino.GetComponent<StockData>().TouchP2 == 1)
                {
                    buttoncondition = 1;
                    selectM.PlayOneShot(selectmusic);
                    select--;           //セレクト番号を1増やす
                }
            }
            if (Arduino.GetComponent<StockData>().ButtonP1 == 0 && Arduino.GetComponent<StockData>().TouchP1 == 0 && Arduino.GetComponent<StockData>().ButtonP2 == 0 && Arduino.GetComponent<StockData>().TouchP2 == 0){
                buttoncondition = 0;
            }

                if (select >= 9)
            {
                select = 0;
            }
            if (select <= -1)
            {
                select = 8;
            }
        }

    }

    void selectbackground()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (backgroundflag == 0)
            {
                blackback.SetActive(false);
                background.SetActive(true);
                backgroundflag = 1;
            }
            else if (backgroundflag == 1)
            {
                blackback.SetActive(true);
                background.SetActive(false);
                backgroundflag = 0;
            }
        }

    }

    public void ChangeTheText()
    {
        if(EASYMODE == 0)
        {
            newText = "小学生向け\nイージーモード\nに変更する";
        }
        else
        {
            newText = "中学生以上\nノーマルモード\nに変更する"; 
        }
        // テキストを変更
        textComponent.text = newText;
    }
}
