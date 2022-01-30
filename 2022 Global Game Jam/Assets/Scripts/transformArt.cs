using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformArt : MonoBehaviour
{
    public Vector3 target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
        transform.Translate (target * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
