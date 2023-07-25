using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDamageSistem : MonoBehaviour
{
    private Transform father;

    private void Start()
    {
        father = transform.parent;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(GameObject.Find(transform.parent.name));
    }

}
