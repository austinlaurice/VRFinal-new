using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttun : MonoBehaviour, Condition{
    private bool pushed;
    private GameObject stair;
    public bool isTrue()
    {
        return !pushed;
    }

    public void push()
    {
        if(!pushed)
        {
            pushed = true;
            stair.SetActive(true);
        }
    }

    // Use this for initialization
    void Start () {
        pushed = false;
        stair = GameObject.Find("Structure").transform.Find("stairs").gameObject;
	}
	
}
