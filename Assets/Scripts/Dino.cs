using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public float velocidade;
    public float tempoPulo;
    private float tempoPulado;
    private Vector3 posicaoInicial;
    private Animator anim;
    private SpriteRenderer sprite;
    public GameObject textoQtdCogumelos;
    private int qtdCogumelos;
    void Start()
    {
        posicaoInicial = this.transform.position;
        anim = this.GetComponent<Animator>();
        sprite = this.GetComponent<SpriteRenderer>();
        qtdCogumelos = 0;
        AtualizarHUD();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) Andar(true);
        if (Input.GetKey(KeyCode.A)) Andar(false);
        if (Input.GetKey(KeyCode.W) && tempoPulado <= 0) Pular();
        tempoPulado -= Time.deltaTime;
        VerificarMorte();
        AtualizarAnimacao();
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
        if(col.gameObject.tag == "cogumelo_bom")
        {
            qtdCogumelos++;
            AtualizarHUD();
            Destroy(col.gameObject);
        }
    }

    void AtualizarHUD()
    {
        textoQtdCogumelos.GetComponent<Text>().text = qtdCogumelos.ToString();
    }

    void Andar(bool andandoParaFrente)
    {
        if (andandoParaFrente)
        {
            sprite.flipX = false;
            Vector3 pos = this.transform.position;
            pos.x += velocidade;
            this.transform.position = pos;
        }
        else
        {
            sprite.flipX = true;
            Vector3 pos = this.transform.position;
            pos.x -= velocidade;
            this.transform.position = pos;
        }
    }
    void Pular()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector2 forca = new Vector2(0f, 10f);
        rb.AddForce(forca, ForceMode2D.Impulse);
        tempoPulado = tempoPulo;
        anim.SetBool("estaPulando", true);
    }
    void VerificarMorte()
    {
        if (this.transform.position.y < -14f)
        {
            this.transform.position = posicaoInicial;
        }
    }
    void AtualizarAnimacao()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("estaAndando", true);
        }
        else
        {
            anim.SetBool("estaAndando", false);
        }
    }
}

