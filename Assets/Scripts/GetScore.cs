using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetScore : MonoBehaviour
{
    public GameObject Arduino;
    public Text result;
    public int player1_score;

    public static int backgroundflag;

    // Start is called before the first frame update
    void Start()
    {
        backgroundflag = Setting.backgroundflag;
    }

    // Update is called once per frame
    void Update()
    {

        result.text = "Player1 : " + TotalScore.score_p1 + "\n" + "Player2 : " + TotalScore.score_p2 + "\n" + "Center : " + TotalScore.score_p3 + "\n" + "Total : " + TotalScore.total;
        player1_score = TotalScore.score_p1;

        if (Input.GetKeyDown(KeyCode.Space) || Arduino.GetComponent<StockData>().RValuebin == 1)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
