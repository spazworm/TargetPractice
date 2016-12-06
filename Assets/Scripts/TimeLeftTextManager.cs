using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLeftTextManager : MonoBehaviour {

    public static TimeLeftTextManager instance { get; private set; }

    private float startTime;
    private float endTime;

    private Text text;

	// Use this for initialization
	void Start () {
        instance = this;
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
            text.text = "Running:" + Mathf.Round(GetTime() * 100f) / 100f;
	}

    public float GetTime()
    {
        if (startTime != 0 && endTime == 0)
        {
            return (Time.time - startTime);
        }
        else
        {
            return (endTime - startTime);
        }
    }

    public void StartTimer()
    {
        if(startTime == 0)
        {
            startTime = Time.time;
        }
    }

    public void StopTimer()
    {
        endTime = Time.time;
    }


}
