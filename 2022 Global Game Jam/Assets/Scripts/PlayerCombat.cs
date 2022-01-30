using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Combat
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AttackEnemy();
    }
    private void AttackEnemy()
    {
        if(canAttack)
        {
            if(Input.GetKeyUp(KeyCode.F))
            {
                if(target != null)
                {
                    target.GetComponent<Enemy>().TakeDamage(1);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            canAttack = true;
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            canAttack = false;
            target = null;
        }
    }
}
