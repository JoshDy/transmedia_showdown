using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnAnyButton : MonoBehaviour {
    // Update is called once per frame
    void Update () {
		if (Input.anyKey)
        {
            Invoke("ChangeLevel", 2.0f);
        }
	}

    void ChangeLevel()
    {
        SceneManager.LoadScene(2);
    }
}
