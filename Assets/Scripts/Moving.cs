using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField]
    public int jumpForce = 200;
    [SerializeField]
    private int speed = 10;
    [SerializeField]
    private bool canJump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    private void jump()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Espacio pulsado");
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            canJump = true;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("barrier"))
        {
            canJump = true;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("limit"))
        {
            canJump = true;
        }

    }

    void move()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        // rotate towards movement direction
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        transform.position += Time.deltaTime * moveDirection.normalized * speed;
    }

    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Hit " + hit.collider.gameObject.name); // imprime el nombre del objeto con el que hace hit
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
            Debug.Log("Did not Hit");
        }
    }
}




