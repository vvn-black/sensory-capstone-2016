using UnityEngine;
using System.Collections;

public class ColliderDetector : MonoBehaviour
{
    private AVPuzzleDeathScript deathScript;

    void Start()
    {
        deathScript = GameObject.Find("Death").GetComponent<AVPuzzleDeathScript>();
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hit " + col.collider.tag);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Hit " + col.tag);
    }
}
