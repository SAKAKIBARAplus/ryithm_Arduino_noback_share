using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public int count = 0;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    private CheckTiming player1_check;
    private CheckTiming player2_check;
    private RingCheckTiming player3_check;

    public static int total;
    public static int score_p1;            //1のスコア
    public static int score_p2;            //2のスコア
    public static int score_p3;            //3のスコア

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        player1_check = player1.GetComponent<CheckTiming>();
        player2_check = player2.GetComponent<CheckTiming>();
        player3_check = player3.GetComponent<RingCheckTiming>();
    }

    // Update is called once per frame
    void Update()
    {

            score_p1 = player1_check.score;
            score_p2 = player2_check.score;
            score_p3 = player3_check.score;

            total = score_p1 + score_p2 + score_p3;
    }
}
