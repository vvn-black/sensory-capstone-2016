using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    public float safeTime = 3.0f;
    public float dangerTime = 11.0f;
    public bool safe, danger;
    public AudioSource countdown, warning, ding;

    float elapsedTime;

    public void ResetVisualTimer()
    {
        elapsedTime = 0.0f;
    }

    public void ResetAll()
    {
        ResetVisualTimer();
        safe = false;
        danger = true;
        countdown.Stop();
        warning.Stop();
        ding.Stop();
        countdown.Play();
    }

    void Start()
    {
        ResetVisualTimer();
        danger = true;
        safe = false;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (danger)
        {
            if (!countdown.isPlaying)
            {
                countdown.Play();
            }

            if (elapsedTime >= dangerTime)
            {
                ResetVisualTimer();
                danger = false;
                safe = true;
                if (!ding.isPlaying)
                {
                    ding.Play();
                }
            }
        }
        else
        {
            if (elapsedTime >= safeTime-1)
            {
                if (!warning.isPlaying)
                {
                    warning.Play();
                }
            }
            if (elapsedTime >= safeTime)
            {
                ResetVisualTimer();
                safe = false;
                danger = true;
            }
        }
    }
}
