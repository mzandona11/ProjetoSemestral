using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
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

        skin.GetComponent<Animator>().Play("Jump",-1);
        rigid.AddForce(new Vector2(0, impulse), ForceMode2D.Impulse);

    }

    void dash(){

        skin.GetComponent<Animator>().Play("Dash",-1);
        rigid.AddForce(new Vector2(6 * Input.GetAxisRaw("Horizontal") , 0), ForceMode2D.Impulse);
        
    }

    void attack(){

        if (numCombo == 1 && contCombo <= 1)
        {
            skin.GetComponent<Animator>().Play("Attack2",-1);
            numCombo = 0;    
        }else
        {
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
        }
    }
}
