using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    bool isJumpKeyPressed;
    float horizontalInput;
    Rigidbody rigidComponent;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] LayerMask playerMask;

    void Start()
    {
        rigidComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpKeyPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rigidComponent.velocity = new Vector3(horizontalInput, rigidComponent.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f,playerMask).Length == 0)
            return;
            if (isJumpKeyPressed)
        {
            rigidComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            isJumpKeyPressed = false;
        }
        
    }
} 
