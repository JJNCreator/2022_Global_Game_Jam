using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float turnSmoothTime = 0.1f;

    private float gravity = 9f;
    private float verticalSpeed;

    private float turnSmoothVelocity;

    private Transform transformCache;
    private CharacterController cController;
    private Vector3 moveDirection;
    private CameraMovement camMovement;

    private void Awake()
    {
        camMovement = FindObjectOfType<CameraMovement>();
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
        if(cController.isGrounded)
        {
            verticalSpeed = 0f;
        }
        verticalSpeed -= gravity * Time.deltaTime;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camMovement.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transformCache.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir.y = verticalSpeed;
            cController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
