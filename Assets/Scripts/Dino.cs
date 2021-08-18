using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public float velocidade;
    public float tempoPulo;
    private float tempoPulado;
    private Vector3 posicaoInicial;
    private Animator anim;
    private SpriteRenderer sprite;
    void Start()
    {
        posicaoInicial = this.transform.position;
        anim = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            sprite.flipX = false;
            Vector3 pos = this.transform.position;
            //pos.x = pos.x + velocidade;
            pos.x += velocidade;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            sprite.flipX = true;
            Vector3 pos = this.transform.position;
            //pos.x = pos.x + velocidade;
            pos.x -= velocidade;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.W) && tempoPulado <= 0)
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 forca = new Vector2(0f, 10f);
            rb.AddForce(forca, ForceMode2D.Impulse);
            tempoPulado = tempoPulo;
            anim.SetBool("estaPulando", true);
        }
        tempoPulado -= Time.deltaTime;
        if(this.transform.position.y < -14f)
        {
            this.transform.position = posicaoInicial;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("estaAndando", true);
        }
        else
        {
            anim.SetBool("estaAndando", false);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "cogumelo_ruim")
        {
            this.transform.position = posicaoInicial;
        }
        if(col.gameObject.tag == "chao")
        {
            anim.SetBool("estaPulando", false);
        }
    }

}

