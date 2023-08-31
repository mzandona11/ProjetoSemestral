using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCollision : MonoBehaviour
{
    public Transform[] bats;

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
            foreach (Transform item in bats)
            {
                item.GetComponent<BatController>().enabled = true;
            }
        }
    }
}
