using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourMug : MonoBehaviour {

    public float speed = 2;
    private ParticleSystem waterfall;
	// Use this for initialization
	void Start () {
        waterfall = GameObject.Find("waterfall").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Pickable>().isPicked())
        {
            Vector3 angle = transform.localEulerAngles;
            if (Input.GetButton("Fire1"))
            {
                float y = -Input.GetAxis("Horizontal");
                if (angle.z < 180 && y < 0 || (angle.z < 90 || angle.z > 180) && y > 0)
                {
                    transform.Rotate(0, 0, y * speed);
                }
            }
            if(angle.z > 45 && angle.z < 100)
            {
                waterfall.Play();
            }
            else
            {
                waterfall.Stop();
            }
        }
	}
}
