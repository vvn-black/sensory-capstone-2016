using UnityEngine;
using System;

public class GlobalTimer : MonoBehaviour
{
    public float safeTime = 3.0f;
    public float dangerTime = 10.0f;
    public bool safe, danger;

    float elapsedTime;

    public void ResetVisualTimer()
    {
        elapsedTime = 0.0f;
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
            if (elapsedTime >= dangerTime)
            {
                ResetVisualTimer();
                danger = false;
                safe = true;
            }
        }
        else
        {
            if (elapsedTime >= safeTime)
            {
                ResetVisualTimer();
                safe = false;
                danger = true;
            }
        }
    }
}
