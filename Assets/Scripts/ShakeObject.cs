using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    public ShakeShake shake;                //対象を揺らすやつ
    public float duration;
    public float magnitude;

    public void shakeobject()
    {
        shake.Shake(duration, magnitude);       //判定地点を揺らす
    }

}
