using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private Transform transformCache;
    private CharacterController cController;
    private Vector3 moveDirection;

    private void Awake()
    {
        cController = GetComponent<CharacterController>();
        transformCache = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            cController.Move(direction * moveSpeed * Time.deltaTime);
        }
    }
}
