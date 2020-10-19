using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] AnimationCurve shakeCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);
    public IEnumerator Shake(float duration, float magnitude, AnimationCurve curve, float predelay)
    {
        yield return new WaitForSeconds(predelay);
        Vector3 OriginalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float shakiness = curve.Evaluate(elapsed / duration);
            float x = Random.Range(-1f, 1f) * magnitude * shakiness;
            float y = Random.Range(-1f, 1f) * magnitude * shakiness;

            transform.localPosition = new Vector3(x, y, OriginalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = OriginalPosition;
    }
}
