using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {
    private DeathScript deathScript;

    void Start()
    {
        deathScript = GetComponentInParent<DeathScript>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            deathScript.KillPlayer();
        }
    }
}
