using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    [SerializeField] AudioClip[] stepsSounds;

    public void PlayStep()
    {
        gameObject.GetComponent<AudioSource>().clip = stepsSounds[Random.Range(0, stepsSounds.Length)];
        gameObject.GetComponent<AudioSource>().Play();

    }
}
