using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeLock : MonoBehaviour, Condition {
    public Camera camera;
    public string answer;
    public double duration = 0.5;
    private int counter;
    private string prevDir;
    private string progress;
    private int now;
    private bool opened;

    public bool isTrue()
    {
        return opened;
    }

    // Use this for initialization
    void Start () {
        counter = 0;
        progress = "0";
        now = 0;
        opened = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(camera.enabled && !opened)
        {
            float h = Input.GetAxis("Horizontal");
            if (prevDir != "right" && h > 0.1)
            {
                counter = 0;
                prevDir = "right";
                now = (now + 1) % 4;
                progress += now.ToString();
            }
            else if (prevDir != "left" && h < -0.1)
            {
                counter = 0;
                prevDir = "left";
                now = (now + 3) % 4;
                progress += now.ToString();
            }
            else if (h < 0.1 && h > -0.1)
            {
                counter = 0;
                prevDir = null;
            }
            else
            {
                if (++counter > 20)
                {
                    counter = 0;
                    prevDir = null;
                }
            }
            transform.localEulerAngles = new Vector3(0, 90 * now, 0);
            if(progress.Length > answer.Length)
            {
                progress = progress.Substring(progress.Length - answer.Length);
            }
            if(progress == answer)
            {
                opened = true;
            }
        }
	}
}
