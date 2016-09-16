using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathScript : MonoBehaviour {
    public GameObject playerObject;
    private RigidbodyFirstPersonController playerScript;

    public void Start()
    {
        playerScript = playerObject.GetComponent<RigidbodyFirstPersonController>();
    }

    public void KillPlayer()
    {
        playerObject.transform.position = new Vector3(playerScript.startingLocation.x, playerScript.startingLocation.y, playerScript.startingLocation.z);
    }
}
