using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view : MonoBehaviour
{
    private Vector3 offset;
    private Transform player;
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();

        offset = player.position - transform.position;
        
    }

    void Update()
    {
        transform.position = player.position - offset;

       
    }
}
