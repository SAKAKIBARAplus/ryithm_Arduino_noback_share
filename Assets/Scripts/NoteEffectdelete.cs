using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEffectdelete : MonoBehaviour
{
    public float deletetime;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, deletetime);
    }
}
