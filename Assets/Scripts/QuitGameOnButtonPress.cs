using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameOnButtonPress : MonoBehaviour {
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Invoke("Quit", 0.0f);
        }
    }

    void quit()
    {
        Application.Quit();
    }
}
