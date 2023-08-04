using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Transform direction;

    [SerializeField] float speed = 1.0f;

    [SerializeField] Transform bugBot;

    [SerializeField] GameObject enemyDead;

    [SerializeField] AudioClip[] enemyDeadSound;

    //limit edge
    Vector3 positionColision;

    void Start()
    {
        direction = GameObject.Find("Direction").GetComponent<Transform>();
    }

    void Update()
    {
        //not allow the player to go out of the map
        if((direction.position - transform.position).magnitude > 48)
        {
            transform.position = positionColision;
        }

        Move();

    }

    //move and rotation
    void Move()
    {
        //for the player see in the right direction
        Rotation(-90, Input.GetAxis("Vertical") < 0);
        Rotation(90, Input.GetAxis("Vertical") > 0 );
        Rotation(0, Input.GetAxis("Horizontal") < 0);
        Rotation(180, Input.GetAxis("Horizontal") > 0);

        //move player
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        //stop animation if the player don't move
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            bugBot.GetComponent<Animator>().speed = 0;
        }
    }

    //changue rotation
    void Rotation(float gradesY, bool condition)
    {
        bugBot.GetComponent<Animator>().speed = 1;

        if (condition)
        {
            bugBot.rotation = Quaternion.Euler(transform.rotation.x, gradesY, transform.rotation.z);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //instantiate particles and sound when the player defeat a enemy
        if (collision.transform.CompareTag("Enemy"))
        {
            Instantiate(enemyDead, collision.gameObject.transform.position, Quaternion.identity);
            gameObject.GetComponent<AudioSource>().clip = enemyDeadSound[Random.Range(0,enemyDeadSound.Length)];
            gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //assing limit
        if(other.gameObject.CompareTag("edge"))
        {
            positionColision = transform.position;
        }      
    }
}
