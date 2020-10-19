using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    
    [SerializeField] private float duration = 2f;
    [SerializeField, Range(0f,2f)] private float magnitude = .2f;
    public IEnumerator Shake(float? d=null, float? m=null)
    {
        Vector3 OriginalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < (d.HasValue?d.Value:duration))
        {
            float x = Random.Range(-1f, 1f) * (m.HasValue?m.Value:magnitude)*Mathf.Sin(elapsed);
            float y = Random.Range(-1f, 1f) * (m.HasValue?m.Value:magnitude)*Mathf.Sin(elapsed);

            transform.localPosition = new Vector3(x, y, OriginalPosition.z);
            
            elapsed += Time.deltaTime;
            
            yield return null;
        }

        transform.localPosition = OriginalPosition;
    }
}
