using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    public Transform pontoA;

    public Transform pontoB;

    public Transform pontoC;

    public Transform pontoD;

    public Vector3 proximaPosicao;

    // Start is called before the first frame update
    void Start()
    {
        proximaPosicao = pontoA.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == pontoA.position)
        {
            proximaPosicao = pontoB.position;
        }

        if (transform.position == pontoB.position)
        {
            proximaPosicao = pontoC.position;
        }

        if (transform.position == pontoC.position)
        {
            proximaPosicao = pontoD.position;
        }

        if (transform.position == pontoD.position)
        {
            proximaPosicao = pontoA.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, proximaPosicao, 10 * Time.deltaTime);
        transform.Rotate(0,0,-1000 * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }

}
