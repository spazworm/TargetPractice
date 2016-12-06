using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreenLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject scoreLabel = GameObject.Find("Panel/ScoreLabel");
        Text text = scoreLabel.GetComponent<Text>();
        Debug.Log("about to print it and its " + GameController.Instance.lastGameTime, null);
        text.text = (Mathf.Round(GameController.Instance.lastGameTime * 100f) / 100f).ToString();

    }

    // Update is called once per frame
    void Update () {
	
	}
}
