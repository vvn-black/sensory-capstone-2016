using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AVPuzzleDeathScript : MonoBehaviour {
    public GameObject playerObject;
    public float speed = 2.0f;
    public int frameDurationOfShock = 100;
    private RigidbodyFirstPersonController playerScript;
    private bool playerDead;
    private int f;

    public void Start()
    {
        playerScript = playerObject.GetComponent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if (playerDead)
        {
            if (f  < frameDurationOfShock)
            {
                f++;
                //Shock player
                playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, new Quaternion(playerObject.transform.rotation.x + 90, playerObject.transform.rotation.y, playerObject.transform.rotation.z, 0), Time.deltaTime * speed);
            }
            if (f >= frameDurationOfShock)
            {
                playerDead = false;
                Restart();
                f = 0;
            }
        }
    }

    public void KillPlayer()
    {
        playerDead = true;
    }

    public void Restart()
    {
        playerObject.transform.position = new Vector3(playerScript.startingLocation.x, playerScript.startingLocation.y, playerScript.startingLocation.z);
        playerObject.transform.eulerAngles = new Vector3(0, playerScript.startingLocation.rotation, 0);
        playerScript.mouseLook.Init(playerObject.transform, playerScript.cam.transform);
    }

    public IEnumerator ShowWinMessage(string message, float delay)
    {
        GetComponent<GUIText>().text = message;
        GetComponent<GUIText>().enabled = true;
        yield return new WaitForSeconds(delay);
        GetComponent<GUIText>().enabled = false;
        Restart();
    }
}
