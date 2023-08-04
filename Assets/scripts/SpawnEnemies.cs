using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    //limits of intantiate
    [SerializeField] private float x;
    [SerializeField] private float Z;
   

    [SerializeField] private GameObject enemy;

    [SerializeField] private List<GameObject> enemiesPool;

    [SerializeField] private SceneControl sceneControl;

    private Vector3 positionToInstantiate;

    private void Start()
    {
        Spawn();
        StartCoroutine(TimeSpawn());
        AddObjectsToPool(5);

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

        for (int i = 0;i < enemiesPool.Count;i++)
        {
            if (!enemiesPool[i].activeSelf)
            {
                ActiveEnemy(i);
                return;
            }
        }

        AddObjectsToPool(1);

        ActiveEnemy(enemiesPool.Count - 1);

        return;
    }


    void ActiveEnemy(int i)
    {
        float randomX;
        float randomZ;

        randomX = Random.Range((x / 2) * 1, (x / 2) * -1);

        randomZ = Random.Range((Z / 2) * 1, (Z / 2) * -1);

        positionToInstantiate = new Vector3(randomX, 0.5f, randomZ);

        enemiesPool[i].transform.position = transform.position + positionToInstantiate;

        enemiesPool[i].SetActive(true);
    }

    //create objects
    private void AddObjectsToPool(int initialObj)
    {
        for (int i = 0;i < initialObj; i++)
        {
            GameObject e = Instantiate(enemy,transform);
            e.SetActive(false);
            enemiesPool.Add(e);

            sceneControl.soundEfects.Add(e.transform.GetChild(0));
        }

 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(x,1,Z));
    }
}
