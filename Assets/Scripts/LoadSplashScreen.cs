using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSplashScreen : MonoBehaviour {

    [SerializeField]
    private float delay = 4f; //Sets the delay before loading the next scene
    [SerializeField]
    private string sceneNameToLoad; //Stores which scene to load

    private float timeElapsed; //Stores the amount of time that a scene has been displayed for

    private void Update () {
        timeElapsed += Time.deltaTime; //Turns the value of this variable to seconds

        if (timeElapsed > delay) //The code below will be run if the time in the scene exceeds the allowed delay
        {
            SceneManager.LoadScene(sceneNameToLoad); //Loads the scene that is listed in the editor
        }
    }

}
