using UnityEngine;
using System.Collections;

public class TileLight : MonoBehaviour {

	public Color _light = new Color(0.0f, 1.0f, 0.71f, 1.0f);
	public Color _off = new Color(0.0f, 0.0f, 0.0f, 1.0f);
	public float min = 0.0f;
	public float max = 1.0f;
	public float changeTime = 0.0f;
	public bool LightOn = false;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		if (LightOn == true) {
			if (changeTime <= max) {
				EmissionOn ();
			}


		} 
		else {
			Renderer renderer = GetComponent<Renderer> ();
			Material mat = renderer.material;

			mat.SetColor ("_EmissionColor", _off);
		}
	
	}

	void OnTriggerEnter(Collider col){
		LightOn = true;

	}
	void EmissionOn () {
		Renderer renderer = GetComponent<Renderer> ();
		Material mat = renderer.material;

		float emissionStrength = Mathf.Lerp (min, max, changeTime * Time.deltaTime);
		//changeTime += 0.2f * Time.deltaTime;
		_light.a = emissionStrength;
		//Color finalColor = Light * Mathf.LinearToGammaSpace (emissionStrength);

		mat.SetColor ("_EmissionColor", _light);
	}

}
