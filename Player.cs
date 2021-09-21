using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    bool isJumpKeyPressed;
    float horizontalInput;
    Rigidbody rigidbodyComponent;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] LayerMask playerMask;
    int score;
    [SerializeField] Text ScoreText;
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumpKeyPressed = true;           
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
            return;

        if (isJumpKeyPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            isJumpKeyPressed = false;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==7)
        {
            Destroy(other.gameObject);
            score += 5;
            ScoreText.text = "Score:" + score;
        }
    }
}
