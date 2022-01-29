using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayAbilities : MonoBehaviour
{
    public GameObject dodgeIcon;
    public GameObject sprintIcon;
    

    // Start is called before the first frame update
    void Start()
    {
        dodgeIcon.SetActive(false);
        sprintIcon.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            dodgeIcon.SetActive(true);
        }
        if (Input.GetKeyUp("q"))
        {
            dodgeIcon.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            sprintIcon.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            sprintIcon.SetActive(false);
        }

    }
}
