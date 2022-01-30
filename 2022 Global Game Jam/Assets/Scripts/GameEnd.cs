using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;
    public Health healthScript;

    // Start is called before the first frame update
    void Start()
    {
        win.SetActive(false);
        lose.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       //if (sth)
       //{
       //     win.SetActive(true);
       // }

        if (healthScript.Dead)
        {
            lose.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
