using UnityEngine;
using System.Collections;

public class RGDeathTrigger : MonoBehaviour {
    private RGDeathScript deathScript;

    void Start()
    {
        deathScript = GetComponentInParent<RGDeathScript>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            deathScript.KillPlayer();
        }
    }
}
