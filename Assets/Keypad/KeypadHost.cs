using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadHost : MonoBehaviour, Condition {
    public string[,] layout = new string[4,3]{
        {"1", "2", "3" },
        {"4", "5", "6" },
        {"7", "8", "9" },
        {"C", "0", "enter"}
    };
    public Camera camera;
    private string prevDir;
    private int counter;
    private GameObject selectHint;
	public string password;
    private int r, c;
    private GameObject selected;
	private string nowInput {
		set {
			monitor.GetComponent<Text> ().text = value;
		}
		get {
			return monitor.GetComponent<Text> ().text;
		}
	}
	private bool unLocked;
	private GameObject monitor;

	// Use this for initialization
	void Start () {
        selected = null;
		monitor = transform.Find("canvas").Find ("monitor").gameObject;
		nowInput = "";
		unLocked = false;
        counter = 0;
        selectHint = transform.Find("select").gameObject;
	}

    private void Update()
    {
        if (camera.enabled)
        {
            float h = Input.GetAxis("Horizontal");
            float v = -Input.GetAxis("Vertical");
            if (!selected)
            {
                r = 0;
                c = 0;
            }
            else if (prevDir != "right" && h > 0.1 && c < 2)
            {
                counter = 0;
                prevDir = "right";
                c += 1;
            }
            else if (prevDir != "left" && h < -0.1 && c > 0)
            {
                counter = 0;
                prevDir = "left";
                c -= 1;
            }
            else if (prevDir != "down" && v > 0.1 && r < 3)
            {
                counter = 0;
                prevDir = "down";
                r += 1;
            }
            else if (prevDir != "up" && v < -0.1 && r > 0)
            {
                counter = 0;
                prevDir = "up";
                r -= 1;
            }
            else if (v < 0.1 && v > -0.1 && h < 0.1 && h > -0.1)
            {
                counter = 0;
                prevDir = null;
            }
            else
            {
                if(++counter > 20)
                {
                    counter = 0;
                    prevDir = null;
                }
            }
            if(selected)
            {
                selected.GetComponent<KeypadKey>().selected = false;
            }
            selected = transform.Find(layout[r,c]).gameObject;
            selected.GetComponent<KeypadKey>().selected = true;
            selectHint.transform.position = selected.transform.position;
            selectHint.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            if(selected) selected.GetComponent<KeypadKey>().selected = false;
            selected = null;
            selectHint.GetComponent<Renderer>().enabled = false;
        }
    }

    public void InputText(string text) {
		if (unLocked)
			return;
		if (text == "C") {
			nowInput = "";
		} else if (text == "≫") {
			if (nowInput == password) {
				unLocked = true;
				nowInput = "Unlocked";
			} else {
				nowInput = "Wrong";
			}
		} else {
            if(nowInput == "Wrong")
            {
                nowInput = "";
            }
			nowInput += text;
		}
	}

	public bool isTrue () {
		return unLocked;
	}
}
