using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
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
            collision.GetComponent<Character>().life--;

            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
        }
    }
}
