using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

    [SerializeField] public List<Transform> soundEfects;


    public void Play()
    {
        SceneManager.LoadScene(1);

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);

    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

    //cotrol the volume according to the type of object
    public  void SoundEfect(float volume)
    {

        float volumeMax = 0;

        foreach (var sound in soundEfects)
        {

            if (sound.CompareTag("Player"))
            {
                volumeMax = 0.3f;
            }
            else if(sound.CompareTag("Hole"))
            {
                volumeMax = 0.5f;
            }
            else if(sound.CompareTag("Crab"))
            {
                volumeMax = 0.2f;
            }
            else if (sound.CompareTag("Roket"))
            {
                volumeMax = 0.7f;
            }

            sound.GetComponent<AudioSource>().volume = volumeMax * volume;
                        
        }
    }
}
