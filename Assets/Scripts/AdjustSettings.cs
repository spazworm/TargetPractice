using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustSettings : MonoBehaviour {

	public void AdjustMouseSpeed()
    {
        Slider mouseSlider = GameObject.Find("MouseSlider").GetComponent<Slider>();
        float sliderValue = mouseSlider.value;
        PlayerPrefs.SetFloat("MouseSpeed", sliderValue);
        Debug.Log("Adjusting Mouse Speed and the new value is: " + sliderValue);
    }
}
