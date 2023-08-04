using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeDamageSistem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lives;

    [SerializeField] private int numLives = 5;


    [SerializeField] private AudioClip[] soundSuccess;

    [SerializeField] private GameObject screenDefeat;

    private void Start()
    {
       lives.text = "lives: " + numLives;
        Time.timeScale = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //play sound 
            gameObject.GetComponent<AudioSource>().clip = soundSuccess[Random.Range(0, soundSuccess.Length)];
            gameObject.GetComponent<AudioSource>().Play();
            
            //show lives and review if is defeat
            numLives--;
            lives.text = "lives: " + numLives;
            if (numLives == 0)
            {
                Time.timeScale = 0f;
                screenDefeat.SetActive(true);
            }

        }
    }

}
