using UnityEngine;
using System.Collections;

public class BasicTileScript : MonoBehaviour
{
    public bool isAudioTrap;
    public bool isInstandDeathTrap;
    public bool isTimedTrap;
    public bool isVisualTrap;
    private InstantDeathTrapScript instantDeathTrap;

    // Use this for initialization
    void Start ()
    {
        instantDeathTrap = gameObject.GetComponent<InstantDeathTrapScript>();

        // Disable all trap type scripts ...
      //  audioTrap.enabled = false;
        instantDeathTrap.enabled = false;
       // timedTrap.enabled = false;
        //visualTrap.enabled = false;

        // ... then enable only the one checked by the game designer
        if (isAudioTrap)
        {
            //audioTrap.enabled = true;
        }
        else if (isInstandDeathTrap)
        {
            instantDeathTrap.enabled = true;
        }
        else if (isTimedTrap)
        {
            //timedTrap.enabled = true;
        }
        else if (isVisualTrap)
        {
            //visualTrap.enabled = true;
        }
    }
}
