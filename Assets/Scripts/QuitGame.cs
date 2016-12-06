using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	public void ExitApplication () {
        Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey("escape")) {
            ExitApplication();
        }
	}
}
