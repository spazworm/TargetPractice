using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemaningTargetsTextManager : MonoBehaviour {

    public static RemaningTargetsTextManager instance { get; private set;}
	// Use this for initialization
	void Start () {
        instance = this;
        updateRemainingTargets();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateRemainingTargets()
    {
        int remaining = GameObject.FindGameObjectsWithTag("ActiveTarget").Length;
        int total = GameObject.FindGameObjectsWithTag("InactiveTarget").Length + remaining;
        Text text = GetComponent<Text>();
        text.text = "Targets: " + remaining + "/" + total;
        if(remaining == 0)
        {
            TimeLeftTextManager.instance.StopTimer();
            SceneChanger sc = new SceneChanger();
            sc.LoadSceneById(2);
            float gameTime = TimeLeftTextManager.instance.GetTime();
            Debug.Log("The game time at this point was " + gameTime, null);
            GameController.Instance.lastGameTime = gameTime;
            Debug.Log("Regrabbing it and the time is " + GameController.Instance.lastGameTime, null);
        }
    }
}
