using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource CoinCollectedSound;

    void OnCollisionEnter(Collision collision)
    {
        CoinCollectedSound.Play();
    }
}
