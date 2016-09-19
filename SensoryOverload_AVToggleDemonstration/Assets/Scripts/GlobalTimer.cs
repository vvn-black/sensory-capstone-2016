using UnityEngine;
using System;

public class GlobalTimer : MonoBehaviour {

    public enum LightColor { Green, Yellow, Red };
    public GameObject lightCollection;

    public float greenTime = 3.0f;
    public float yellowTime = 1.0f;
    public float redTime = 5.0f;
    public int repetitions = 2;

    public Color greenLightColor = Color.green;
    public Color yellowLightColor = Color.yellow;
    public Color redLightColor = Color.red;

    public AudioSource green;
    public AudioSource yellow;
    public AudioSource red;

    LightColor _currentColor;
    public LightColor currentColor
    {
        get { return _currentColor; }
        set
        {
            _currentColor = value;
            switch (_currentColor)
            {
                case LightColor.Green:
                    foreach (Light light in lights)
                        light.color = greenLightColor;
                    break;
                case LightColor.Yellow:
                    foreach (Light light in lights)
                        light.color = yellowLightColor;
                    break;
                case LightColor.Red:
                default:
                    foreach (Light light in lights)
                        light.color = redLightColor;
                    break;
            }
        }
    }

    Light[] lights;
    float elapsedTime;
    int elapsedRepetitions;

    public void ResetVisualTimer()
    {
        currentColor = LightColor.Green;
        elapsedTime = 0.0f;
        elapsedRepetitions = 0;
    }

    void Start()
    {
        lights = lightCollection.GetComponentsInChildren<Light>();
        ResetVisualTimer();
    }

    void Update()
    {
        // visual timing
        if (elapsedRepetitions < repetitions)
            elapsedTime += Time.deltaTime;
        if (currentColor == LightColor.Green && elapsedTime >= greenTime)
        {
            currentColor = LightColor.Yellow;
            playYellow();
            elapsedTime = 0.0f;
        }
        else if (currentColor == LightColor.Yellow && elapsedTime >= yellowTime)
        {
            currentColor = LightColor.Red;
            playRed();
            elapsedTime = 0.0f;
        }
        else if (currentColor == LightColor.Red && elapsedTime >= redTime)
        {
            elapsedRepetitions++;
            elapsedTime = 0.0f;
            if (elapsedRepetitions < repetitions)
            {
                currentColor = LightColor.Green;
                playGreen();
            }
        }
    }

    void playGreen()
    {
        red.Stop();
        yellow.Stop();
        green.Play();
    }

    void playYellow()
    {
        red.Stop();
        green.Stop();
        yellow.Play();
    }

    void playRed()
    {
        green.Stop();
        yellow.Stop();
        red.Play();
    }
}
