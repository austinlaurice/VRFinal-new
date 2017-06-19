using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomIn : MonoBehaviour, IPointerClickHandler
{
    public Camera camera;
    private ZoomInDisplay display;
    public void OnPointerClick(PointerEventData eventData)
    {
        display.setCamera(camera);
    }

    // Use this for initialization
    void Start () {
        display = GameObject.Find("FirstPersonCharacter").transform.Find("ZoomInDisplay").gameObject.GetComponent<ZoomInDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
