using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    public GameObject trappedPrisoner;
    private bool canPlayerInteract = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlayerInteract)
        {
            if(Input.GetKeyUp(KeyCode.I))
            {
                GameManager.Instance.cagesFreedCount++;
                Destroy(trappedPrisoner);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canPlayerInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canPlayerInteract = false;
        }
    }
}
