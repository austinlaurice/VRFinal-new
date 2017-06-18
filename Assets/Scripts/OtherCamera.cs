using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCamera : MonoBehaviour {
    public RenderTexture texture;
    public GameObject display;
    private Camera mainCamera;
    private Camera camera;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        camera = gameObject.GetComponent<Camera>();
	}

    private 
	
	// Update is called once per frame
	void Update () {
		if(camera.isActiveAndEnabled)
        {
            if(Input.GetButtonUp("Fire2"))
            {
                camera.targetTexture = null;
            }
        }
	}

    public void SwitchTo()
    {
        if(mainCamera.isActiveAndEnabled)
        {
            mainCamera.enabled = false;
            camera.enabled = true;
        }
    }
}
