using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float rotateSpeed;

    public bool canMove = false;

    private Transform transformCache;

    private void Awake()
    {
        transformCache = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            transformCache.rotation = Quaternion.Slerp(transformCache.rotation, Quaternion.LookRotation(target.position - transformCache.position), rotateSpeed * Time.deltaTime);
            transformCache.position += transformCache.forward * moveSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canMove = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canMove = false;
        }
    }
}
