using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class DoorLock : MonoBehaviour, IPointerClickHandler, Condition {
    public string keyName;
    private bool unlocked;
    public bool isTrue()
    {
        return unlocked;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Pickable.itemName() == keyName)
        {
            Pickable.useItem();
            unlocked = true;
        }
    }

    // Use this for initialization
    void Start () {
        unlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
