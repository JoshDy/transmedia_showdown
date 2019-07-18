using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationScript : MonoBehaviour {

    public AudioSource navigate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0) //Runs the code below if the player is holding the e key down
        {
            navigate.Play();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) //Runs the code below if the player is holding the e key down
        {
            navigate.Play();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetAxis("Vertical2") > 0 || Input.GetAxis("Vertical2") < 0) //Runs the code below if the player is holding the e key down
        {
            navigate.Play();
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetAxis("Horizontal2") > 0 || Input.GetAxis("Horizontal2") < 0) //Runs the code below if the player is holding the e key down
        {
            navigate.Play();
        }
    }
}
