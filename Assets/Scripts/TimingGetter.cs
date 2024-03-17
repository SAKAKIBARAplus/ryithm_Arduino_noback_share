using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingGetter : MonoBehaviour
{
    const string notename = "note(Clone)";
    public GameObject judge_point;
    public CheckTiming checktiming;

    // Start is called before the first frame update
    void Start()
    {
        checktiming = judge_point.GetComponent<CheckTiming>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == notename)
        {
           checktiming.Timing[this.gameObject.name].Add(other.gameObject);
            //Debug.Log(other.gameObject.name);
            if (this.gameObject.name == "perfect")
            {
                other.gameObject.GetComponent<Renderer>().material.color = new Color(0.6f,1f,0.5f);
            }else if(this.gameObject.name == "good")
            {
                other.gameObject.GetComponent<Renderer>().material.color = new Color(0.75f, 1f, 0.5f);
            }
            else
            {
                other.gameObject.GetComponent<Renderer>().material.color = new Color(0.9f, 1f, 0.5f);
            }
        }
        //Debug.Log(other.gameObject.name);
        //Debug.Log("aaa");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == notename)
        {
            checktiming.Timing[this.gameObject.name].RemoveAt(0);
            other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            if (this.gameObject.name == "good")
            {
                checktiming.combo = 0;
                checktiming.judge = "bad";
                checktiming.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);      //赤色にする
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
