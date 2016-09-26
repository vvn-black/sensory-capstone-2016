using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RGDeathScript : MonoBehaviour {
    public GameObject playerObject;
    private RigidbodyFirstPersonController playerScript;
    private RGGlobalTimer timer;

    public void Start()
    {
        playerScript = playerObject.GetComponent<RigidbodyFirstPersonController>();
        timer = GetComponentInParent<RGGlobalTimer>();
    }

    void Update()
    {
        if (timer.currentColor == RGGlobalTimer.LightColor.Red && 
            (playerScript.Velocity.magnitude > 0.05 || playerScript.Velocity.magnitude < -0.05))
            KillPlayer();
    }

    public void KillPlayer()
    {
        playerObject.transform.position = new Vector3(playerScript.startingLocation.x, playerScript.startingLocation.y, playerScript.startingLocation.z);
        playerObject.transform.eulerAngles = new Vector3(0, playerScript.startingLocation.rotation, 0);
        playerScript.mouseLook.Init(playerObject.transform, playerScript.cam.transform);
        timer.ResetVisualTimer();
    }
}
