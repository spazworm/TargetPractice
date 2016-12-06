using UnityEngine;
using System.Collections;

public class StartGameTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter()
    {
        TimeLeftTextManager.instance.StartTimer();
    }
}
