using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger2 : MonoBehaviour {

    public int damage = 5;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Player"))
        {
            col.SendMessageUpwards("Damage", damage);
        }
    }

}
