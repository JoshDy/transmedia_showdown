using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ContinueSound.Instance.gameObject.GetComponent<AudioSource>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
