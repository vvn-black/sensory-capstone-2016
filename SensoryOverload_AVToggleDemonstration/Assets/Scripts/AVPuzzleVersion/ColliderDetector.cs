using UnityEngine;
using System.Collections;

public class ColliderDetector : MonoBehaviour
{
    private AVPuzzleDeathScript deathScript;
    private bool nearPowerSwitch = false;
    public GameObject electricty;
    public GameObject powerSwitch;

    void Start()
    {
        deathScript = GameObject.Find("Death").GetComponent<AVPuzzleDeathScript>();
    }

    void Update()
    {
        if (nearPowerSwitch)
        {
            if (Input.GetButtonDown("Jump"))
            {
                electricty.SetActive(false);
                powerSwitch.GetComponent<ParticleSystem>().startColor = new Color(1, 0, 0, 1);
                powerSwitch.GetComponent<AudioSource>().enabled = false;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Electricity")
        {
            deathScript.KillPlayer();
        }

        if (col.gameObject.tag == "Exit")
        {
            StartCoroutine(deathScript.ShowWinMessage("You Win!", 3));
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Power")
        {
            nearPowerSwitch = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Power")
        {
            nearPowerSwitch = false;
        }
    }
}
