using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeypadKey : MonoBehaviour{
	private GameObject host;
	private string key;
    public bool selected;
	// Use this for initialization
	void Start () {
		key = transform.Find("Canvas").Find("Text").GetComponent<Text> ().text;
		host = transform.parent.gameObject;
        selected = false;
	}

	void Update() {
        if(selected)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                host.GetComponent<KeypadHost>().InputText(key);
            }
        }
	}
}
