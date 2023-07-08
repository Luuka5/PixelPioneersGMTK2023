using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CameraShake : MonoBehaviour
    {
    public IEnumerator Shake(float duration, float magnitude)
        {

        Vector3 originalPos = transform.localPosition;
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                float Offset = Random.Range(-0.5f, 0.5f) * magnitude;
                float y0ffset = Random.Range(-0.5f, 0.5f) * magnitude;
                transform.localPosition = new Vector3(Offset, y0ffset, originalPos.z);
                elapsedTime += Time.deltaTime;
                // wait one frame
                yield return null;
                
            }

        transform.localPosition = originalPos;
    }
}