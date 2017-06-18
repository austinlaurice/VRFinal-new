using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class ZoomInDisplay : MonoBehaviour {
    private Camera nowCamera;
    private RenderTexture texture;
    public FirstPersonController fpsController;
	// Use this for initialization
	void Start () {
        nowCamera = null;
        texture = gameObject.GetComponent<RenderTexture>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2"))
        {
            setCamera(null);
        }
	}

    public void setCamera(Camera camera)
    {
        if(nowCamera)
        {
            //nowCamera.targetTexture = null;
            nowCamera.enabled = false;
            nowCamera = null;
        }
        gameObject.SetActive(false);
        fpsController.enabled = true;

        if (camera)
        {
            nowCamera = camera;
            //nowCamera.targetTexture = texture;
            camera.enabled = true;
            gameObject.SetActive(true);
            fpsController.enabled = false;
        }
    }
}
