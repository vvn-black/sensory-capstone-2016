using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathScript : MonoBehaviour
{
    public GameObject playerObject;
    private RigidbodyFirstPersonController playerScript;
    private GlobalTimer timer;

    public void Start()
    {
        playerScript = playerObject.GetComponent<RigidbodyFirstPersonController>();
        timer = GetComponentInParent<GlobalTimer>();
    }

    void Update()
    {
        /*if ()
            KillPlayer;*/
    }

    public void KillPlayer()
    {
        playerObject.transform.position = new Vector3(playerScript.startingLocation.x, playerScript.startingLocation.y, playerScript.startingLocation.z);
        playerObject.transform.eulerAngles = new Vector3(0, playerScript.startingLocation.rotation, 0);
        playerScript.mouseLook.Init(playerObject.transform, playerScript.cam.transform);
        //timer.ResetVisualTimer();
        Debug.Log("Player killed!");
    }
}
