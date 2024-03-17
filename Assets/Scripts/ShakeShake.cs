using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeShake : MonoBehaviour
{
    Vector3 pos;

    private void Start()
    {
        pos = transform.localPosition;
    }

    public void Shake(float duration,float magnitude )
    {
        StartCoroutine(DoShake(duration, magnitude));
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        var elapsed = 0.0f;

        while(elapsed < duration)
        {
            var x = pos.x + Random.Range(-1.0f, 1.0f) * magnitude;
            var y = pos.y + Random.Range(-1.0f, 1.0f) * magnitude;

            transform.localPosition = new Vector3(x,y,pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;
    }
}
