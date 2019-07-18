using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateCharacter : MonoBehaviour {

    public Text player1health;

    void Start ()
    {
        if (CharacterSelection.player1 != null)
        {
            GameObject player1 = (GameObject)Instantiate(CharacterSelection.player1);
            player1.GetComponent<playerHealth>().text = player1health;
        } else
        {
            Debug.Log("Player 1 GameObject not assigned.");
        }
	}
	
}
