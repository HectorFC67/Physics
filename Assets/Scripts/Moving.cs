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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Time.deltaTime * Vector3.forward * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Time.deltaTime * Vector3.back * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Time.deltaTime * Vector3.left * speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Time.deltaTime * Vector3.right * speed;
        }
    }
}




