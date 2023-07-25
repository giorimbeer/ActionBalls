using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    //limits of intantiate
    [SerializeField] private Transform rightBorder;
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform topBorder;
    [SerializeField] private Transform bottomBorder;

    [SerializeField] private GameObject enemy;

    private Vector3 positionToInstantiate;

    private void Start()
    {
        Spawn();
        StartCoroutine(TimeSpawn());
    }


    IEnumerator TimeSpawn()
    {
        while (true) 
        { 
            yield return new WaitForSeconds(5);
            for (int i = 0; i < 1; i++)
            {
                Spawn();
            }      
        }
        
    }


    void Spawn()
    {
        float randomX = Random.Range(leftBorder.position.x, rightBorder.position.x);

        float randomz = Random.Range(bottomBorder.position.z, topBorder.position.z);

        positionToInstantiate = new Vector3(randomX, 0.5f, randomz);

        Instantiate(enemy, positionToInstantiate, Quaternion.identity);
    }
}
