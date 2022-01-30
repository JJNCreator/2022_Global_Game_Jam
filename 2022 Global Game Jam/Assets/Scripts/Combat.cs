using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject target;
    public bool canAttack = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator DamageLoop()
    {
        yield return new WaitForSeconds(1.5f);

        //Debug.Log("Combat:DamageLoop()");

        if(canAttack)
        {
            Health.Instance.TakeDamage(1);
        }
        StartCoroutine(DamageLoop());
    }
}
