using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapController : MonoBehaviour
{
    public Transform skin;

    Transform player;

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
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().SetBool("run", false);

            
            skin.GetComponent<Animator>().Play("Trap", -1);
            collision.GetComponent<Character>().PlayerDamage(1);

            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            collision.transform.position = transform.position;



            player = collision.transform;

            collision.GetComponent<PlayerController>().enabled = false;

            Invoke("realeasePlayer", 2);

            transform.GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    void realeasePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }
}
