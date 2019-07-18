using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour {

    public static GameObject selectedlevel;

    public GameObject level1prefab;
    public GameObject level2prefab;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChooseBackground1()
    {
        selectedlevel = level1prefab;
    }

    public void ChooseBackground2()
    {
        selectedlevel = level2prefab;
    }
}
