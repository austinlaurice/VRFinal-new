using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    static private HashSet<string> loadedScenes = new HashSet<string>();
    public string scene;
    public Vector3 position;
	// Use this for initialization
	void Start () {
        loadedScenes.Add(Application.loadedLevelName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void change()
    {
            if (!loadedScenes.Contains(scene))
            {
                Application.LoadLevelAdditive(scene);
                loadedScenes.Add(scene);
            }
            GameObject.Find("FPSController").transform.position = position;
            //SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            change();
        }
    }
}
