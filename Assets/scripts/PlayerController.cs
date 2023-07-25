using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private Transform direction;

    private bool canJump = true;

    [SerializeField] float speed = 1.0f;

    [SerializeField] float forceJump = 1.0f;

    [SerializeField] Transform topBorder;

    [SerializeField] Transform bottomBorder;

    [SerializeField] Transform letBorder;

    [SerializeField] Transform rightBorder;

    Vector3 positionColision;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        direction = GameObject.Find("Direction").GetComponent<Transform>();
    }

    void Update()
    {
        if (transform.position.x <= letBorder.position.x)
        {
            transform.position = positionColision;
        }
        else if (transform.position.x >= rightBorder.position.x)
        {
            transform.position = positionColision;
        }
        else if (transform.position.z <= bottomBorder.position.z)
        {
            transform.position = positionColision;
        }
        else if (transform.position.z >= topBorder.position.z)
        {
            transform.position = positionColision;
        }
        

        if (transform.position.y < 0.5f)
        {
            transform.position = new Vector3(transform.position.x,0.5f,transform.position.z);
        }



        Move();

    }

    void Move()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed, ForceMode.Impulse);
        //rb.AddForce(Vector3.forward * Input.GetAxis("Vertical") * speed, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(direction.up * forceJump, ForceMode.Impulse);

        }
        else if (Input.GetKeyDown(KeyCode.Space) && !canJump)
        {
            rb.AddForce(direction.up * forceJump * -2, ForceMode.Impulse);
        }
    }

    void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("ground") && !canJump)
        {
            canJump = true;
        }

        if (collision.transform.CompareTag("Enemy") && transform.position.y >= 1.4f)
        {
            DestroyEnemy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {

            positionColision = transform.position;
        }
    }
}
