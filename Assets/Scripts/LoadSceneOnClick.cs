using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public int sceneIndex;

    public void LoadByIndex(int sceneIndex) {
        Invoke("ChangeLevel", 1.0f);
        
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene(sceneIndex); //Loads the scene referenced by this index number if a button is pressed
    }
}
