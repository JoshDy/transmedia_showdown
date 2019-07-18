using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack2 : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.6f;

    public Collider2D attackTrigger;

    void Awake()
    {
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !attacking || Input.GetAxis("Attack2") > 0.3 && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;

                if (attackTimer == 0)
                {
                    attacking = false;
                    attackTrigger.enabled = true;
                }
            }

            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}

