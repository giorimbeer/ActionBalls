using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;


public class  EnemyController: MonoBehaviour
{

    private Transform hole;

    private Vector3 target;

    [SerializeField] public float speed = 1;

    private List<GameObject> points;

    private int random;

    [SerializeField] private Transform crab;

    [SerializeField] private GameObject enemySuccess;

    
    
    void Awake()
    {
        
        hole = GameObject.Find("hole").GetComponent<Transform>();

    }

    private void OnEnable()
    {
        //assing points to move
        GameObject[] arrayPoint = GameObject.FindGameObjectsWithTag("point");

        points = arrayPoint.ToList();

        //chose a point and to move at
        random = UnityEngine.Random.Range(0, points.Count);

        target = (points[random].transform.position - transform.position).normalized;

        crab.LookAt(points[random].transform.position - transform.position, Vector3.up);

        ChangueSpeed();
    }

    void Update()
    {
        //move to the point
        transform.Translate(target * speed * Time.deltaTime);


        //define limits
        if (transform.position.x < -50)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.x > 50)
        {
           gameObject.SetActive(false);
        }        
        if (transform.position.z < -50)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.z > 50)
        {
            gameObject.SetActive(false);
        }


        
    }

    //change speed over time dor add challenge
    void ChangueSpeed()
    {
        if (60 > Time.realtimeSinceStartup)
        {
            speed = 4;
        }
        else if (120 > Time.realtimeSinceStartup)
        {
            speed = 6;
        }
        else if (180 > Time.realtimeSinceStartup)
        {
            speed = 8;
        }
        else if (240 > Time.realtimeSinceStartup)
        {
            speed = 10;
        }
        else if (300 > Time.realtimeSinceStartup)
        {
            speed = 11;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("point"))
        {

            ChangeDirec();
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //victory of enemy efects
        if (collision.gameObject.CompareTag("Hole"))
        {           
            Instantiate(enemySuccess, collision.GetContact(0).point, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    //remove the last point of move and apoint to another
    void ChangeDirec()
    {      
        points.RemoveAt(random);

        if (points.Count != 0)
        {
            random = UnityEngine.Random.Range(0, points.Count);

            target = (points[random].transform.position - transform.position).normalized;

            crab.LookAt(points[random].transform.position - transform.position, Vector3.up);

        }
        else
        {
            target = (hole.position - transform.position).normalized;
        }
    }
}
