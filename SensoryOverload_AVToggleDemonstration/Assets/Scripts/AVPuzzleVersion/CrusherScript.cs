using UnityEngine;
using System.Collections;

public class CrusherScript : MonoBehaviour
{
    public float x = 0;
    public float initialY = 4;
    public float finalY = .7F;
    public float z = 15;
    public float speedDown = 2;
    public float speedUp = 2;
    private float t = 0;
    private bool dropped = false;

	// Update is called once per frame
	void Update ()
    {
	    if (!dropped)
        {
            t += Time.deltaTime * speedDown;
            transform.position = Vector3.Lerp(new Vector3(x, initialY, z), new Vector3(x, finalY, z), t);
            if (transform.position.y <= finalY)
            {
                dropped = true;
                t = 0;
            }
        }
        else
        {
            t += Time.deltaTime * speedUp;
            transform.position = Vector3.Lerp(new Vector3(x, finalY, z), new Vector3(x, initialY, z), t);
            if (transform.position.y >= initialY)
            {
                dropped = false;
                t = 0;
            }
        }
    }
}
