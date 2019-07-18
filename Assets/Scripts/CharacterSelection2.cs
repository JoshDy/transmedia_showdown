using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection2 : MonoBehaviour {

    public static GameObject player2;

    public GameObject paulprefab2;
    public GameObject jaredprefab2;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChoosePaul2()
    {
        player2 = paulprefab2;
    }

    public void ChooseJared2()
    {
        player2 = jaredprefab2;
    }
}
