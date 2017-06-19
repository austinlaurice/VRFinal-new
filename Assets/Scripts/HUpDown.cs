using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUpDown : MonoBehaviour {
    public Camera camera;
    private ZoomInDisplay display;
    private ChangeScene up, down;
	// Use this for initialization
	void Start () {
        display = GameObject.Find("FirstPersonCharacter").transform.Find("ZoomInDisplay").gameObject.GetComponent<ZoomInDisplay>();
        ChangeScene[] css = GetComponents<ChangeScene>();
        foreach(ChangeScene scene in css)
        {
            if (scene.scene == "floor1") down = scene;
            else up = scene;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (camera.enabled)
        {
            float v = Input.GetAxis("Vertical");
            if (v > 0.1)
            {
                display.setCamera(null);
                up.change();
            }
            else if(v < -0.1)
            {
                display.setCamera(null);
                down.change();
            }
        }
	}
}
