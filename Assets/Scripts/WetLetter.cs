using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetLetter : MonoBehaviour {
    
    private int counter;
    private bool wet;
    public Texture wetTextrue;
    public int num2wet = 50;
	// Use this for initialization
	void Start () {
        counter = 0;
        wet = false;
	}

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        if (counter < num2wet && other.name == "waterfall")
        {
            if(++counter >= num2wet)
            {
                wet = true;
                gameObject.GetComponent<Renderer>().material.mainTexture = wetTextrue;
            }
        }
    }
}
