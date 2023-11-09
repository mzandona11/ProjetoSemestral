using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    Transform boss;

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
        if (collision.CompareTag("Enemy"))
        {
            boss = collision.transform;
            collision.transform.parent = transform;

            collision.gameObject.SetActive(false);
            
            
        }
    }

    public void realeseBoss()
    {

        boss.parent = null;
        boss.gameObject.SetActive(true);

    }
}
