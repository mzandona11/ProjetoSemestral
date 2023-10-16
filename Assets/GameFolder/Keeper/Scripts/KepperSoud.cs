using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KepperSoud : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip attackAudio;

    public AudioClip v_dieAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attackAudio1() {
        audioSource.PlayOneShot(attackAudio, 1);
    }

    public void dieAudio()
    {
        audioSource.PlayOneShot(v_dieAudio, 1);

    }
}
