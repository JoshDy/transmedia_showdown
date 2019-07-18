using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public int maxHealth = 200;
    public int curHealth = 200;
    public Text text;

    // Update is called once per frame

    void Update()
    {
        if (curHealth <= 0)
        {
            SceneManager.LoadScene(9);
        }

        string health = curHealth + "/" + maxHealth;
        text.text = health;
    }

    public void AdjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 0)
            curHealth = 0;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        if (maxHealth < 1)
            maxHealth = 1;
    }
   
    public void Damage(int damage)
    {
        curHealth -= damage;
    }
}