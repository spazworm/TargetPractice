using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowSettingsPanel : MonoBehaviour {

    public void Execute()
    {
        GameObject sliderObject = GameObject.Find("MouseSlider");
        if (sliderObject != null)
        {
            Debug.Log("Found the MouseSlider");
            Slider mouseSlider = sliderObject.GetComponent<Slider>();
            if (mouseSlider != null)
            {
                Debug.Log("Found the internal slider");
                mouseSlider.normalizedValue = PlayerPrefs.HasKey("MouseSpeed") ? PlayerPrefs.GetFloat("MouseSpeed") : 0.5f;
            }
            else
            {
                Debug.Log("Internal Slider not found");
            }
        }
        else
        {
            Debug.Log("MouseSlider not found");
        }
    }
}
