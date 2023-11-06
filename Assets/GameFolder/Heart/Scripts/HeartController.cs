using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{

    public AudioClip upLifeAudio;

    public AudioSource v_AudioSource;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            v_AudioSource.PlayOneShot(upLifeAudio,1);
            collision.GetComponent<Character>().life++;
            Invoke("dastroyHeart",0.5f);
        }
    }

    private void dastroyHeart() {
        Destroy(transform.gameObject);
    }


}
