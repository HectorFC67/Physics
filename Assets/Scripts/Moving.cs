using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody riggidBody;
    private bool canJump;
    [SerializeField]
    public int jumpForce = 200;
    [SerializeField]
    float moveSpeed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        riggidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            riggidBody.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
            canJump = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            canJump = false;
        }
    }

    private void Move()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

}