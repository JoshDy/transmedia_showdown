using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackOnButtonPress : MonoBehaviour
{
    public int sceneIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Invoke("ChangeLevel", 0.0f);
        }
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}