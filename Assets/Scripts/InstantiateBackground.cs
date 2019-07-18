using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Instantiate(LevelSelection.selectedlevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
