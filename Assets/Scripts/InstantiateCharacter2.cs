using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateCharacter2 : MonoBehaviour {

    public Text player2health;

    void Start()
    {
        if (CharacterSelection2.player2 != null)
        {
            GameObject player2 = (GameObject)Instantiate(CharacterSelection2.player2);
            player2.GetComponent<playerHealth2>().text = player2health;
        }
        else
        {
            Debug.Log("Player 2 GameObject not assigned.");
        }
    }
}
