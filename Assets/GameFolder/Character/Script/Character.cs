using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int life;

    public Transform skin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life<=0)
        {
            skin.GetComponent<Animator>().Play("Die",-1);
        }

    }

    public void PlayerDamage(int value)
    {
        life = life - value;
        skin.GetComponent<Animator>().Play("PlayerDamage1", 1);
        skin.parent.GetComponent<PlayerController>().audioSource.PlayOneShot(skin.parent.GetComponent<PlayerController>().damageAudio,1);

    }
}
