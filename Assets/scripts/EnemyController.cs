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

    private Rigidbody rb;

    [SerializeField] private float speed = 1;

    private List<GameObject> points;

    private int random;


    void Start()
    {
        GameObject[] arrayPoint = GameObject.FindGameObjectsWithTag("point");

        points = arrayPoint.ToList();

        hole = GameObject.Find("hole").GetComponent<Transform>();

        rb = gameObject.GetComponent<Rigidbody>();

        random = UnityEngine.Random.Range(0, points.Count);

        target = (points[random].transform.position - transform.position).normalized;

        
    }

    
    void Update()
    {
             
        ///transform.Translate(target * speed * Time.deltaTime);

    }

    void FixedUpdate()
    {
    
        rb.AddForce(target * speed, ForceMode.Impulse);

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
        if (collision.gameObject.CompareTag("Hole"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    void ChangeDirec()
    {
        rb.Sleep();

        points.RemoveAt(random);

        if (points.Count != 0)
        {

            random = UnityEngine.Random.Range(0, points.Count);

            target = (points[random].transform.position - transform.position).normalized;
        }
        else
        {
            target = (hole.position - transform.position).normalized;
        }
    }
}
