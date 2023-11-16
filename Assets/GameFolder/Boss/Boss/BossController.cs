using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class BossController : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;

    public Vector2 proximoPonto;

    public Transform laizer;

    public float contLaizer;

    public AudioSource audioSource;

    public AudioClip audioBoss;

    public AudioClip playerWin;

    public Transform victoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        proximoPonto = pontoA.position;

        audioBossM();
    }

    // Update is called once per frame
    void Update()
    {
        contLaizer += Time.deltaTime;

        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;

            audioSource.PlayOneShot(playerWin);
            victoryScreen.GetComponent<CanvasGroup>().alpha = 1;
            victoryScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;

        }

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

    public void audioBossM()
    {
        if (GetComponent<Character>().life > 0)
        {
            Invoke("audioBossM", 6);
            audioSource.PlayOneShot(audioBoss);
        }        
    }


}
