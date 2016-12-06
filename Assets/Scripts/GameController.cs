using UnityEngine;
using System.Collections;

public class GameController {

    private static GameController instance;

    public float lastGameTime;
    public float mouseSpeed;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private GameController()
    {

    }

    public static void Reset()
    {
        instance = null;
    }

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameController();
                instance.mouseSpeed = PlayerPrefs.HasKey("MouseSpeed") ? PlayerPrefs.GetFloat("MouseSpeed") : 0.5f;
                Debug.Log("Loading Game Controller and the mouse speed is: " + instance.mouseSpeed, null);
            }
            return instance;
        }
    }


}
