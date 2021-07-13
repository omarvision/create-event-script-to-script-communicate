using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBall : MonoBehaviour
{
    private void Start()
    {
        AudioSource pop = this.GetComponent<AudioSource>();
        pop.pitch = Random.Range(0.9f, 1.3f);
        pop.Play();
    }
}