using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField]
    public int jumpForce = 85;
    [SerializeField]
    float moveSpeed = 25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
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
