using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {

    public static GameObject player1;

    public GameObject paulprefab;
    public GameObject jaredprefab;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChoosePaul() {
        player1 = paulprefab;
    }

    public void ChooseJared()
    {
        player1 = jaredprefab;
    }
}
