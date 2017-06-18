using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutMugDown : MonoBehaviour {
    public GameObject pointer;
    private Pickable pickable;
	// Use this for initialization
	void Start () {
        pickable = gameObject.GetComponent<Pickable>();
	}
	
	// Update is called once per frame
	void Update () {
        if(pickable.isPicked())
        {
            if(Input.GetButtonDown("Fire2"))
            {
                Debug.Log(pickable.transform.position);
                transform.parent = null;
                transform.position = pointer.transform.position;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
	}
}
