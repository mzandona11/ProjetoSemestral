using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;

    public Vector2 proximoPonto;

    public Transform laizer;

    public float contLaizer;

    // Start is called before the first frame update
    void Start()
    {
        proximoPonto = pontoA.position;
    }

    // Update is called once per frame
    void Update()
    {
        contLaizer += Time.deltaTime;

        if (contLaizer >= 5)
        {
            contLaizer = 0;

            laizer.gameObject.SetActive(false);
            laizer.GetComponent<TrailRenderer>().Clear();

            laizer.position = transform.position;

            laizer.gameObject.SetActive(true);
            
        }


        if (transform.position == pontoA.position)
        {
            proximoPonto = pontoB.position;
        }

        if (transform.position == pontoB.position)
        {
            proximoPonto = pontoA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, proximoPonto, 5 * Time.deltaTime);


    }
}
