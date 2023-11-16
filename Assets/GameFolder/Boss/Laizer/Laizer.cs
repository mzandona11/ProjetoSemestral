using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laizer : MonoBehaviour
{
    Transform player;

    public AudioSource audioSource;

    public AudioClip lazerAudio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = GameObject.Find("Player").transform;

        transform.right = transform.position - player.position;

        audioSource.PlayOneShot(lazerAudio);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * -5 * Time.deltaTime;        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);    
        }
    }
}
