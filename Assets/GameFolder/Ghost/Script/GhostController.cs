using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform pontoA;

    public Transform pontoB;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (Vector2.Distance(transform.position, pontoA.position) <= 0.5f)
        {
            transform.position = pontoB.position;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, pontoA.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }


}
