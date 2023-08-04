using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class view : MonoBehaviour
{
    //distance of the camera in the y axis with respec to the player
    private Vector3 offset;


    private Transform player;

    
    //timer vars
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timerTime;
    private int minutes;
    private int seconds;
    private int miliseconds;



    [SerializeField] private Transform roket;
    [SerializeField] private GameObject endScreen;


    void Awake()
    {

        player = GameObject.Find("player").GetComponent<Transform>();

        offset = player.position - transform.position;

        endScreen.SetActive(false);
        
    }

    void Update()
    {
        //review the time for act as the case may be
        if (timerTime > Time.deltaTime)
        {
            transform.position = player.position - offset;

            timerTime -= Time.deltaTime;
        }
        else
        {
            transform.position = (new Vector3(0,4,15));

            if(roket != null)
            {
                transform.LookAt(roket.position - transform.position);
                roket.GetComponent<Animator>().enabled = true;
                roket.GetComponent<AudioSource>().enabled = true;
                endScreen.SetActive(true);
            }
        }


        minutes = (int)(timerTime / 60);
        seconds = (int)(timerTime - 60 * minutes);
        miliseconds = (int)((timerTime - (int)timerTime) * 100);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
    }
}
