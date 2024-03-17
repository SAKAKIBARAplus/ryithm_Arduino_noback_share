using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string scene;
    public GameObject Arduino;
    private AsyncOperation async;
    public AudioClip fixsound;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //async.allowSceneActivation = false;
        if (Input.GetKeyDown(KeyCode.Space) || Arduino.GetComponent<StockData>().RValuebin == 1)
        {
            audio.PlayOneShot(fixsound);
            changescene();
        }
    }

    void changescene()
    {
        //async.allowSceneActivation = true;
        SceneManager.LoadScene(scene);
    }
}
