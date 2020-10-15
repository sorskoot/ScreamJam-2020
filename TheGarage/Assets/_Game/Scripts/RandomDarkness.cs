using System.Collections;
using UnityEngine;

public class RandomDarkness : MonoBehaviour
{
    private Projector projector;

    private void Start()
    {
        this.projector = GetComponent<Projector>();
        projector.enabled = false;
    }

    public IEnumerator Flicker(float duration, float delay)
    {

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            if (Random.Range(0, 2) == 1)
            {
                projector.enabled = true;
            }
            else
            {
                projector.enabled = false;
            }

            yield return new WaitForSeconds(delay); ;
            elapsed += Time.deltaTime;
        }

        projector.enabled = false;
    }
}
