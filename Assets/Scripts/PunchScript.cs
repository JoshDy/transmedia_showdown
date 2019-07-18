using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour {

    public AudioSource punch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Attack") > 0) //Runs the code below if the player is holding the e key down
        {
            punch.Play();
        }

        if (Input.GetKeyDown(KeyCode.O) || Input.GetAxis("Attack2") > 0) //Runs the code below if the player is holding the e key down
        {
            punch.Play();
        }
    }
}
