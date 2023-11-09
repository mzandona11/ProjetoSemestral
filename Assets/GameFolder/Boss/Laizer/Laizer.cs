using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laizer : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = GameObject.Find("Player").transform;

        transform.right = transform.position - player.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * -5 * Time.deltaTime;        
        
    }
}
