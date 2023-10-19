using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float impulse;
    public bool isJump;
    public int numCombo;
    public float contCombo;

    
    Rigidbody2D rigid;

    public Transform skin;

    public Text playerLife_UI;

    public string currentLevel;

    public AudioSource audioSource;

    public AudioClip dashAudio;

    public AudioClip attack1Audio;

    public AudioClip attack2Audio;

    public AudioClip groundedAudio;

    public AudioClip upAudio;

    public AudioClip gameOverAudio;

    public AudioClip damageAudio;

    public Transform pauseScreen;


    // Start is called before the first frame update
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();

        currentLevel = SceneManager.GetActiveScene().name;

        DontDestroyOnLoad(transform.gameObject);

        audioSource = GetComponent<AudioSource>();

     }

    // Update is called once per frame
    void Update()
    {
        if (!currentLevel.Equals(SceneManager.GetActiveScene().name) )
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
        }

        if (GetComponent<Character>().life <= 0)
        {
            audioSource.PlayOneShot(gameOverAudio, 1);
            this.enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }


        contCombo += Time.deltaTime;

        move();

        if (Input.GetButtonDown("Jump") && isJump)
        {
            jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            attack();
        }

        if (Input.GetButtonDown("Fire3") && isJump)
        {
            dash();
        }

        playerLife_UI.text = "x" + GetComponent<Character>().life.ToString();
    }

    void move(){

        Vector3 moviment = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        transform.position += moviment * speed * Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.localScale = new Vector3(5,5,5);
            }else
            {
                transform.localScale = new Vector3(-5,5,5);
            }
            skin.GetComponent<Animator>().SetBool("run",true);
        }else
        {
            skin.GetComponent<Animator>().SetBool("run",false);
        }
        
    }

    void jump(){

        audioSource.PlayOneShot(upAudio, 1);
        skin.GetComponent<Animator>().Play("Jump",-1);
        rigid.AddForce(new Vector2(0, impulse), ForceMode2D.Impulse);

    }

    void dash(){

        audioSource.PlayOneShot(dashAudio,1);

        skin.GetComponent<Animator>().Play("Dash",-1);
        rigid.AddForce(new Vector2(6 * Input.GetAxisRaw("Horizontal") , 0), ForceMode2D.Impulse);
        
    }

    void attack(){

        if (numCombo == 1 && contCombo <= 1)
        {
            audioSource.PlayOneShot(attack2Audio, 1);
            skin.GetComponent<Animator>().Play("Attack2",-1);
            numCombo = 0;    
        }else
        {
            audioSource.PlayOneShot(attack1Audio, 1);
            skin.GetComponent<Animator>().Play("Attack1",-1);
            contCombo = 0;
            numCombo = 1;    
        }

        skin.GetComponent<Animator>().Play("Attack1",-1);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor"))
        {

            
            isJump= true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJump = false;
            audioSource.PlayOneShot(groundedAudio, 1);            
        }
    }

    public void destroyPlayer() {
        Destroy(transform.gameObject);
    }
}
