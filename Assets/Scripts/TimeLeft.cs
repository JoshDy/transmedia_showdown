using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour {

    public Text text; //Stores the values of the timer in this text gameobject
    float timer = 51f; //Sets up the timer so that it starts at a certain amount of seconds

    void Update () {

        timer -= Time.deltaTime; //Sets up the timer so that it counts down in real time

        int seconds = (int)(timer % 60); //Calculates how the value of a second will look
        int minutes = (int)(timer / 60) % 60; //Calculates how the value of a minute will look

        string timerString = string.Format("{0:0}:{1:00}",minutes,seconds); //Sets up the format of the timer to be in minutes and seconds

        text.text = timerString; //Sets the format of the the timer to be in minutes and seconds

        if (timer <= 0) //Runs the code below if the timer reaches 0
        {
            SceneManager.LoadScene(7); //Load the scene referenced by this index number (Game Over Screen)
        }
    }
}
