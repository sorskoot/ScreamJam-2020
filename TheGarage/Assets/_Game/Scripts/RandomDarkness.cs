using System.Collections;
using UnityEngine;

public class RandomDarkness : MonoBehaviour
{

    // [SerializeField] private float duration = 2f;
    // [SerializeField] private float delay = .2f;
    [SerializeField, Range(0f,1f)] private float balance = .5f;

    private Projector projector;

    private void Start()
    {
        this.projector = GetComponent<Projector>();
        projector.enabled = false;
    }

    public IEnumerator Flicker(float duration, float delay, float predelay)
    {
        yield return new WaitForSeconds(predelay);

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            if (Random.Range(0f, 1f) >= balance)
            {
                projector.enabled = true;
            }
            else
            {
                projector.enabled = false;
            }

            yield return new WaitForSeconds(delay); ;
            elapsed += delay;
        }

        projector.enabled = false;
    }
}
