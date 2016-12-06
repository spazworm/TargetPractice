using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public void LoadSceneById(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
